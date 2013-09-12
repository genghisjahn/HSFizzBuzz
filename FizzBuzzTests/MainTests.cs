using System;
using System.Linq;
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FizzBuzzLib;
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
            var fbitem = new FBItem(3, "Fizz");
            var resultarray=new int[by3.Length];
            
            foreach (int i in by3)
            {
                FBResult fbresult = fbitem.GetResult(i);
                if (fbresult.Text != "Fizz" && fbresult.FBValue.HasValue == true)
                {
                    break;
                }
            }

            

            
            
        }

        [TestMethod]
        public void NonMultiples_Of_3_Return_Number_Test()
        {
            var notby3 = GetNonMultiplesByDivisor(3, numbers);
            var fbitem = new FBItem(3, "Fizz");
            var result = fbitem.GetResult(notby3.First());

            var expected = new FBResult(notby3.First(),null);
            Assert.AreEqual(expected.ToString(), result.ToString());
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
