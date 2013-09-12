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
            var fbitem3 = new FBDivisorItem(3, "Fizz",3);
            bool condcheck = CheckForCondition(numstocheck, new List<IFBItem> { fbitem3 }, "Fizz");
            Assert.IsTrue(condcheck == false);
        }

        [TestMethod]
        public void NonMultiples_Of_3_Return_Number_Test()
        {
            var notby3 = GetNonMultiplesByDivisor(3, numbers);
            var fbitem3 = new FBDivisorItem(3, "Fizz",3);
            bool condcheck = CheckForCondition(notby3, new List<IFBItem> { fbitem3 }, null);

            Assert.IsTrue(condcheck == false);

        }

        [TestMethod]
        public void Multiples_Of_5_Return_Buzz_Test()
        {
            var numstocheck = GetMultiplesByDivisor(5, numbers);
            var fbitem5 = new FBDivisorItem(5, "Buzz",5);
            bool condcheck = CheckForCondition(numstocheck, new List<IFBItem> { fbitem5 }, "Buzz");
            Assert.IsTrue(condcheck == false);
        }

        [TestMethod]
        public void NonMultiples_Of_5_Return_Number_Test()
        {
            var notby5 = GetNonMultiplesByDivisor(5, numbers);
            var fbitem5 = new FBDivisorItem(5, "Buzz",5);
            bool condcheck = CheckForCondition(notby5, new List<IFBItem> { fbitem5 }, null);

            Assert.IsTrue(condcheck == false);

        }

        [TestMethod]
        public void Multiples_Of_15_Return_FizzBuzz_Test()
        {
            var numstocheck = GetMultiplesByDivisor(15, numbers);
            var fbitem15 = new FBDivisorItem(15, "FizzBuzz",15);
            bool condcheck = CheckForCondition(numstocheck, new List<IFBItem> { fbitem15 }, "FizzBuzz");
            Assert.IsTrue(condcheck == false);
        }

        [TestMethod]
        public void NonMultiples_Of_15_Return_Number_Test()
        {
            var numstocheck = GetNonMultiplesByDivisor(15, numbers);
            var fbitem15 = new FBDivisorItem(15, "FizzBuzz",15);
            bool condcheck = CheckForCondition(numstocheck, new List<IFBItem> { fbitem15 }, null);
            Assert.IsTrue(condcheck == false);
        }

        [TestMethod]
        public void Multiples_Of_15_Return_FizzBuzz_With_15_5_3_Items_Test()
        {
            var numstocheck = GetMultiplesByDivisor(15, numbers);
            var fbitem15 = new FBDivisorItem(15, "FizzBuzz",15);
            var fbitem5 = new FBDivisorItem(5, "Buzz",5);
            var fbitem3 = new FBDivisorItem(3, "Fizz",3);
            bool condcheck = CheckForCondition(numstocheck, new List<IFBItem> { fbitem15, fbitem5, fbitem3 }, "FizzBuzz");

            Assert.IsTrue(condcheck == false);

        }

        [TestMethod]
        public void All_3_Fizz_5_Buzz_15_FizzBuzz_Test()
        {
            var m15 = GetMultiplesByDivisor(15, numbers);
            var m3 = GetMultiplesByDivisor(3, numbers).Where(n=>!m15.Contains(n)).ToArray();
            var m5 = GetMultiplesByDivisor(5, numbers).Where(n => !m15.Contains(n)).ToArray();
            

            var other = numbers.Where(n => !m3.Contains(n) && !m5.Contains(n) && !m15.Contains(n)).ToArray();

            var fb15 = new FBDivisorItem(15, "FizzBuzz",15);
            var fb5 = new FBDivisorItem(5, "Buzz",5);
            var fb3 = new FBDivisorItem(3, "Fizz",3);
            
            

            var fbroc = new FBProcessor(numbers,new List<IFBItem> { fb15, fb5, fb3 });

            var procresults = fbroc.GetResults();

            var m3count = procresults.Where(n => n.Text == "Fizz").Count();
            var m5count = procresults.Where(n => n.Text == "Buzz").Count();
            var m15count = procresults.Where(n => n.Text == "FizzBuzz").Count();
            var othercount = procresults.Where(n => n.Text == null).Count();

            Assert.IsTrue(m3.Count() == m3count && m5.Count() == m5count && m15.Count() == m15count && othercount == other.Count());

        }

        private static bool CheckForCondition(int[] numstocheck, List<IFBItem> fbitems, string textcheck)
        {
            var fbproc = new FBProcessor(numstocheck, fbitems);
            var results = fbproc.GetResults();
            bool conditioncheck = false;
            foreach (int i in numstocheck)
            {
                foreach (IFBItem fbi in fbitems.OrderByDescending(fb=>fb.OrderCheck))
                {
                    FBResult fbresult = fbi.GetResult(i);
                    if (fbresult.Text == textcheck) break;
                    if (fbresult.Text != textcheck && fbresult.FBValue.HasValue == true)
                    {
                        conditioncheck = true;
                        break;
                    }
                }
            }
            return conditioncheck;
        }

        private static int[] GetMultiplesByDivisor(int divisor,int[] nums)
        {
            int[] result = nums.Where(n => n % divisor == 0 ).ToArray();
            return result;
        }
        private static int[] GetNonMultiplesByDivisor(int divisor, int[] nums)
        {
            int[] result = nums.Where(n => n % divisor != 0).ToArray();
            return result;
        }
    }
}
