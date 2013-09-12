using System;
using System.Linq;
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FizzBuzzLib;
using FizzBuzzLib.Interfaces;
using System.Collections.Generic;
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
            var numstocheck = GetMultiplesByDivisor(3, numbers);
            var fbitem3 = new FBDivisorItem(3, "Fizz");
            bool nofizzcheck = CheckAllForSingleCondition(numstocheck,new List<IFBItem> { fbitem3 },"Fizz");    
            Assert.IsTrue(nofizzcheck == false);
        }

        [TestMethod]
        public void Multiples_Of_5_Return_Buzz_Test()
        {
            var numstocheck = GetMultiplesByDivisor(5, numbers);
            var fbitem5 = new FBDivisorItem(5, "Buzz");
            bool nofizzcheck = CheckAllForSingleCondition(numstocheck, new List<IFBItem> { fbitem5 }, "Buzz");
            Assert.IsTrue(nofizzcheck == false);
        }

       
        [TestMethod]
        public void NonMultiples_Of_3_Return_Number_Test()
        {
            var notby3 = GetNonMultiplesByDivisor(3, numbers);
            var fbitem3 = new FBDivisorItem(3, "Fizz");
            bool fizzcheck = CheckAllForSingleCondition(notby3, new List<IFBItem> { fbitem3 }, null);
            
            Assert.IsTrue(fizzcheck == false);

        }

        private static bool CheckAllForSingleCondition(int[] numstocheck, List<IFBItem> fbitems, string textcheck)
        {
            var fbproc = new FBProcessor(numbers, fbitems);
            var results = fbproc.GetResults();
            bool conditioncheck = false;
            foreach (int i in numstocheck)
            {
                FBResult fbresult = fbitems.First().GetResult(i);
                if (fbresult.Text != textcheck && fbresult.FBValue.HasValue == true)
                {
                    conditioncheck = true;
                    break;
                }
            }
            return conditioncheck;
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
