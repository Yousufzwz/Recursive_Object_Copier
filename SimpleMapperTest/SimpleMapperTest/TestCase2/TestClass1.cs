using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMapperTest.TestCase2
{
    public class TestClass1
    {
        public SubClass2 Class2 { get; set; }
        public List<SubClass2> SubClasses { get; set; }
        public Temp1 Temp { get; set; }
        public Temp1[] Temps { get; set; }
    }
}
