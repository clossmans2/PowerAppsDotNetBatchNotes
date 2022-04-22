using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.Data;

namespace Training.Test {
    public class DogTests {
        //positive testing, tests that something suceeds
        //negative tests, tests that something fails

        [Test]
        public void DogMoves() {
            Dog testDog = new Dog("Test dog", "black", true);

            Assert.AreEqual("I ran 10", testDog.Move(10));
            Assert.AreEqual("I ran 35", testDog.Move(35));
            Assert.AreEqual("I ran 5", testDog.Move(5));
        }

        [Test]
        public void DogSpeaks() {
            Dog testDog = new Dog("Test dog", "black", true);

            Assert.AreEqual("Bark", testDog.Speak());
        }

        [Test]
        public void DogCompareToFalse() {
            Dog testDog1 = new Dog("Test dog", "black", true);
            Dog testDog2 = new Dog("Test_dog", "blue", true);

            Assert.AreNotEqual(0, testDog1.CompareTo(testDog2)); //return -1
        }

        [Test]
        public void DogCompareTo() {
            Dog testDog1 = new Dog("Test dog", "black", true);
            Dog testDog2 = new Dog("Test_dog", "blue", true);

            Assert.AreEqual(-1, testDog1.CompareTo(testDog2));
            Assert.AreEqual(1, testDog2.CompareTo(testDog1));
        }
    }
}
