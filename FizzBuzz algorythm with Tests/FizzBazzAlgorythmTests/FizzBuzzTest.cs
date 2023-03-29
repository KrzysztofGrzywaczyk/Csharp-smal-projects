using NUnit.Framework;
using FizzBuzz_algorithm;

namespace FizzBuzzAlgorythmTests
{
    public class FizzBuzzTest
    {
        [Test]
        public void FizzBuzz_WhenArgumentDivisibleBy3and5_ShouldReturnFizzBuzz()
        {
            var result = FizzBuzz.FizzBuzzMethod(15);
            Assert.AreEqual(result,"FizzBuzz");
        }

        [Test]
        public void FizzBuzz_WhenArgumentDivisibleBy3_ShouldReturnFizz()
        {
            var result = FizzBuzz.FizzBuzzMethod(3);
            Assert.AreEqual(result, "Fizz");

        }

        [Test]
        public void FizzBuzz_WhenArgumentDivisibleBy5_ShouldReturnBuzz()
        {
            var result = FizzBuzz.FizzBuzzMethod(5);
            Assert.AreEqual(result, "Buzz");
        }

        [Test]
        public void FizzBuzz_WhenArgumentNotDivisibleBy3or5_ShouldReturnArgument()
        {
            var result = FizzBuzz.FizzBuzzMethod(2);
            Assert.AreEqual(result, "2");
        }
    }
}