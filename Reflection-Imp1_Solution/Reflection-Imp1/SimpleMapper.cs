using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionImp1;

public class SimpleMapper
{
    public void Copy(object source, object destination)
    {
        PropertyCopier(source, destination, new Dictionary<object, object>());
    }

    private void PropertyCopier(object source, object destination, Dictionary<object, object>traversed)
    {
        if (source == null || destination == null || traversed.ContainsKey(source))
            return;

        traversed[source] = destination;

        Type TypeOfSource = source.GetType();
        Type TypeOfDestination = destination.GetType();

        PropertyInfo[] propertyFromSource = TypeOfSource.GetProperties();
        PropertyInfo[] propertyFromDestination = TypeOfDestination.GetProperties();

        foreach (var ps in propertyFromSource)
        {
            if (ps.CanRead)
            {
                PropertyInfo propertyDestination = propertyFromDestination.FirstOrDefault(p => p.Name == ps.Name);

                if (propertyDestination != null && propertyDestination.CanWrite)
                {
                    var value = ps.GetValue(source);

                    if (value != null)
                    {
                        if (value is IList && propertyDestination.PropertyType.IsGenericType)
                        {
                            ListMappingOperation(value, propertyDestination, destination, traversed);
                        }
                        else if (value.GetType().IsArray && propertyDestination.PropertyType.IsArray)
                        {
                            ArrayMappingOperation(value, propertyDestination, destination, traversed);
                        }
                        else if (!ps.PropertyType.IsPrimitive && ps.PropertyType != typeof(string))
                        {
                            TypeMappingOperation(value, propertyDestination, destination, traversed);
                        }
                        else
                        {
                            propertyDestination.SetValue(destination, value);
                        }
                    }
                    else
                    {
                        propertyDestination.SetValue(destination, null);
                    }
                }
            }
        }
    }

    private void ListMappingOperation(object value, PropertyInfo propertyDestination, object destination, Dictionary<object, object>traversed)
    {
        Type typeOfList = value.GetType();
        IList newList = (IList)Activator.CreateInstance(propertyDestination.PropertyType);

        Type typeOfItem = propertyDestination.PropertyType.GetGenericArguments()[0];

        foreach(var item in (IEnumerable)value)
        {
            var newItem = Activator.CreateInstance(typeOfItem);
            PropertyCopier(item, newItem, traversed);
            newList.Add(newItem);
        }

        propertyDestination.SetValue (destination, newList);
    }


    private void ArrayMappingOperation(object value, PropertyInfo propertyDestination, object destination, Dictionary<object, object> traversed)
    {
        Type typeOfItem = propertyDestination.PropertyType.GetElementType();
        IList newList = new List<object>();

        foreach (var item in (Array)value)
        {
            var newItem = Activator.CreateInstance(typeOfItem);
            PropertyCopier(item, newItem, traversed);
            newList.Add(newItem);
        }

        Array newArray = Array.CreateInstance(typeOfItem, newList.Count);
        for (int i = 0; i < newList.Count; i++)
        {
            newArray.SetValue(newList[i], i);
        }

        propertyDestination.SetValue(destination, newArray);
    }


    private void TypeMappingOperation(object value, PropertyInfo propertyDestination, object destination, Dictionary<object, object>traversed)
    {
        var constructor = propertyDestination.PropertyType.GetConstructor(Type.EmptyTypes);

        if(constructor != null)
        {
            var newObject = constructor.Invoke(null);
            PropertyCopier (value, newObject, traversed);
            propertyDestination.SetValue(destination, newObject);
        }
        else
        {
            propertyDestination.SetValue(destination, null);
        }
    }

}


