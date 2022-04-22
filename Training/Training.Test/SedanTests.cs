using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.Data;

namespace Training.Test {
    //optional attribute that marks a class a containing tests
    //automatically can mark the class with this attribute if there is a method inside the class
    //with the attribute of Test, TestCase, or TestCaseSource
    //[TestFixture]
    public class SedanTests {
        //test driven development
        //you write your tests first, then you write the code to make the tests pass
        private Sedan testCar;

        [OneTimeSetUp]
        public void Init() {
            //this methods runs once before anything else in the file runs. you can only have one
            //would generally create your database, while Setup would add the data
            Console.WriteLine("Inside onetime setup");
        }

        //can have multiple setup and teardown methods
        [SetUp]
        public void Setup() {
            //runs before every test in the file
            //used to setup any connections, data, etc
            Console.WriteLine("Inside the setup method");
            testCar = new Sedan("Honda", "Civic", "2010");
        }

        [Test]
        public void EngineStarts() {
            Assert.AreEqual("Vroom", testCar.StartEngine());
        }

        [Test]
        public void GetInfo() {
            Assert.AreEqual($"I am a 2010 Honda Civic", testCar.GetInfo());
        }

        //can run multiple tests and feed it the test data you would like using the TestCase attribute
        [TestCase("Chrysler", "200", "2013", ExpectedResult = "I am a 2013 Chrysler 200")]
        [TestCase("Toyota", "Camery", "2010", ExpectedResult = "I am a 2010 Toyota Camery")]
        [TestCase("Jeep", "Renegade", "2018", ExpectedResult = "I am a 2018 Jeep Renegade")]
        [TestCase("Ford", "Fiesta", "2000", ExpectedResult = "I am a 2000 Ford Fiesta")]
        public string GetInfoMultiple(string make, string model, string year) {
            Sedan temp = new Sedan(make, model, year);

            return temp.GetInfo();
        }

        //in the case that i do not want a test to be run
        [Test]
        [Ignore("Showing what Ignore attribute does")]
        public void WrongTest() {
            //some test I dont want to run
            Assert.IsTrue(1 < 3);
        }

        //an example of a negative test
        [Test]
        public void GetMileageThrows() {
            Assert.Throws<NotImplementedException>(() => testCar.GetMileage());
        }

        [TearDown]
        public void Teardown() {
            //used to clean up dtaa that was used in the tests
            Console.WriteLine("Inside the teardown method");
            testCar = null;
        }

        [OneTimeTearDown]
        public void CleanUp() {
            //runs once after everything in your test file runs
            //would get rid of any dataabses or anything left over from testing here
            Console.WriteLine("Inside onetime teardown");
        }
    }
}