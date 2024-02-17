using SimpleMapperTest.TestCase1;
using SimpleMapperTest.TestCase2;
using NUnit.Framework.Constraints;
using Shouldly;


namespace SimpleMapperTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            // Arrange
            Product product= new Product();
            product.Name = "Camera";
            product.Colors = new List<Color> { new Color { Name = "White", Code = "#FFF" }, 
                new Color { Name = "Black", Code = "#000" } };
            product.Price = 88899;
            product.Id = 1;
            product.Feedbacks = new Feedback[] { 
                new Feedback { FeedbackGiver = new User { Name = "jalaluddin", Email = "jalaluddin@devskill.com" }, 
                    Comment = "Very good", Rating = 5.0 }, 
                new Feedback { FeedbackGiver = new User { Name = "Hasan", Email = "hasan@yahoo.com" }, 
                    Comment = "OK", Rating = 4.2 }, 
                new Feedback { FeedbackGiver = new User { Name = "Tareq", Email = "tareq@gmail.com" }, 
                    Comment = "Bad item", Rating = 1.6 } };
            Item item = new Item();

            // Act
            //SimpleMapper mapper = new SimpleMapper();
            //mapper.Copy(product, item);

            //SimpleMapper.Copy(product, item);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => item.Name.ShouldBe(product.Name),
                () => item.PhotoUrl.ShouldBeNull(),
                () => item.Colors.ShouldNotBe(product.Colors),
                () => item.Colors[0].ShouldNotBeSameAs(product.Colors[0]),
                () => item.Colors[0].Name.ShouldBe(product.Colors[0].Name),
                () => item.Colors[0].Code.ShouldBe(product.Colors[0].Code),
                () => item.Colors[1].Name.ShouldBe(product.Colors[1].Name),
                () => item.Colors[1].Code.ShouldBe(product.Colors[1].Code),
                () => item.Description.ShouldBeNull(),
                () => item.Feedbacks.ShouldNotBeSameAs(product.Feedbacks),
                () => item.Feedbacks[0].Rating.ShouldBe(product.Feedbacks[0].Rating),
                () => item.Feedbacks[0].Comment.ShouldBe(product.Feedbacks[0].Comment),
                () => item.Feedbacks[0].FeedbackGiver.ShouldNotBeSameAs(product.Feedbacks[0].FeedbackGiver),
                () => item.Feedbacks[0].FeedbackGiver.Name.ShouldBe(product.Feedbacks[0].FeedbackGiver.Name),
                () => item.Feedbacks[0].FeedbackGiver.Email.ShouldBe(product.Feedbacks[0].FeedbackGiver.Email),
                () => item.Feedbacks[1].Rating.ShouldBe(product.Feedbacks[1].Rating),
                () => item.Feedbacks[1].Comment.ShouldBe(product.Feedbacks[1].Comment),
                () => item.Feedbacks[1].FeedbackGiver.ShouldNotBeSameAs(product.Feedbacks[1].FeedbackGiver),
                () => item.Feedbacks[1].FeedbackGiver.Name.ShouldBe(product.Feedbacks[1].FeedbackGiver.Name),
                () => item.Feedbacks[1].FeedbackGiver.Email.ShouldBe(product.Feedbacks[1].FeedbackGiver.Email),
                () => item.Feedbacks[2].Rating.ShouldBe(product.Feedbacks[2].Rating),
                () => item.Feedbacks[2].Comment.ShouldBe(product.Feedbacks[2].Comment),
                () => item.Feedbacks[2].FeedbackGiver.ShouldNotBeSameAs(product.Feedbacks[2].FeedbackGiver),
                () => item.Feedbacks[2].FeedbackGiver.Name.ShouldBe(product.Feedbacks[2].FeedbackGiver.Name),
                () => item.Feedbacks[2].FeedbackGiver.Email.ShouldBe(product.Feedbacks[2].FeedbackGiver.Email)
            );
        }

        [Test]
        public void Test2()
        {
            // Arrange
            TestClass1 testClass1 = new TestClass1();
            testClass1.Temps = null;
            testClass1.Class2 = new SubClass2() { Property1 = "Hello", Property2 = "Wrold" };
            testClass1.SubClasses = new List<SubClass2>();
            testClass1.Temp = new Temp1() { Temp = new Temp2 { Temp = new Temp3 { } } };
            TestClass2 testClass2 = new TestClass2();


            // Act
            //SimpleMapper mapper = new SimpleMapper();
            //mapper.Copy(testClass1, testClass2);

            //SimpleMapper.Copy(testClass1, testClass2);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => testClass2.Temps.ShouldBeNull(),
                () => testClass2.Temp.ShouldNotBe(testClass1.Temp),
                () => testClass2.SubClasses.ShouldBeNull()
                );
        }
    }
}