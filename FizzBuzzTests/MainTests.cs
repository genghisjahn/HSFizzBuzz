using System;
using System.Linq;
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FizzBuzzLib;
using FizzBuzzLib.Interfaces;
namespace FizzBuzzTests
{
    [TestClass]
    public class MainTests
    {
        private static int[] numbers;

        [ClassInitialize]
        public static void FZTestInitialize(TestContext context)
        {
            numbers = Enumerable.Range(1, 100).ToArray();
        }

        [TestMethod]
        public void Multiples_Of_3_Return_Fizz_Test()
        {
            var by3 = GetMultiplesByDivisor(3, numbers);
            var fbitem3 = new FBDivisorItem(3, "Fizz");
            var fbproc = new FBProcessor(numbers, new System.Collections.Generic.List<IFBItem> { fbitem3 });
            var results = fbproc.GetResults();
            var resultarray=new int[by3.Length];
            bool nofizzcheck = false;
            foreach (int i in by3)
            {
                FBResult fbresult = fbitem3.GetResult(i);
                if (fbresult.Text != "Fizz" && fbresult.FBValue.HasValue == true)
                {
                    nofizzcheck = true;
                    break;
                }
            }
            Assert.IsTrue(nofizzcheck == false);
        }
        [TestMethod]
        public void NonMultiples_Of_3_Return_Number_Test()
        {
            var notby3 = GetNonMultiplesByDivisor(3, numbers);
            var fbitem3 = new FBDivisorItem(3, "Fizz");

            var fbproc = new FBProcessor(numbers, new System.Collections.Generic.List<IFBItem> { fbitem3 });
            var results = fbproc.GetResults();
            var resultarray = new int[notby3.Length];

            bool fizzcheck = false;
            foreach (int i in notby3)
            {
                FBResult fbresult = fbitem3.GetResult(i);
                if (fbresult.Text == "Fizz" && fbresult.FBValue.HasValue == true)
                {
                    fizzcheck = true;
                    break;
                }
            }
            Assert.IsTrue(fizzcheck == false);

        }

        

        private static int[] GetMultiplesByDivisor(int divisor,int[] nums)
        {
            int[] result = nums.Where(n => n % divisor == 0).ToArray();
            return result;
        }
        private static int[] GetNonMultiplesByDivisor(int divisor, int[] nums)
        {
            int[] result = nums.Where(n => n % divisor != 0).ToArray();
            return result;
        }
    }
}
