using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FizzBuzzLib;
using FizzBuzzLib.Interfaces;
using OtherFizzBuzzLib;
namespace FizzBuzz3
{
    class Program
    {
        private static int[] numbers;
        static void Main(string[] args)
        {
            numbers = Enumerable.Range(1, 100).ToArray();
            //var results = ProcessResultsFizz(); //Only multiples of 3 rule.
            //var results = ProcessResultsBuzz(); //Only Multiples of 5 rule.
            //var results = ProcessResultsFizzBuzz(); //Only Multiples of 15 rule.
            //var results = ProcessResultsFullFizzBuzz(); //All three fizzbuzz rules.
            //var results = ProcessResultsFizzAndPalindrome(); //Only multiples of 3 and palindromes.
            //var results = ProcessResultsOutsideAssemblyPalindrome(); //Palindrome rule applied based upon outside implementation of IFBItem.
            
            /*
            foreach (var r in results)
            {
                Console.WriteLine(r.ToString());
            }
            */
            FBDivisorItem fbitem3 = new FBDivisorItem(3, "Fizz");
            FBDivisorItem fbitem5 = new FBDivisorItem(5, "Buzz");
            FBDivisorItem fbitem15 = new FBDivisorItem(15, "FizzBuzz");

            List<IFBItem> fbitems = new List<IFBItem>(){fbitem3,fbitem5,fbitem15};
       
            for (int i = 0; i <= int.MaxValue; i++)
            {
                var result= FBProcessor.GetResult(i, fbitems);
                if(i % 1000000==0 || i<1000 )Console.WriteLine(result);
            }

            Console.ReadKey();
        } 
        #region "Private Result Processors"
        private static FBResult[] ProcessResultsFizz()
        {
            FBDivisorItem fb3 = new FBDivisorItem(3, "Fizz");
            List<IFBItem> fbitems = new List<IFBItem>();
            fbitems.Add(fb3);
            FBProcessor fbproc = new FBProcessor(numbers, fbitems);
            return fbproc.GetResults();
        }
        private static FBResult[] ProcessResultsBuzz()
        {
            FBDivisorItem fb5 = new FBDivisorItem(5, "Buzz");
            List<IFBItem> fbitems = new List<IFBItem>();
            fbitems.Add(fb5);
            FBProcessor fbproc = new FBProcessor(numbers, fbitems);
            return fbproc.GetResults();
        }
        private static FBResult[] ProcessResultsFizzBuzz()
        {
            FBDivisorItem fb15 = new FBDivisorItem(15, "FizzBuzz");
            List<IFBItem> fbitems = new List<IFBItem>();
            fbitems.Add(fb15);
            FBProcessor fbproc = new FBProcessor(numbers, fbitems);
            return fbproc.GetResults();
        }
        private static FBResult[] ProcessResultsFullFizzBuzz()
        {
            FBDivisorItem fb3 = new FBDivisorItem(3, "Fizz");
            FBDivisorItem fb5 = new FBDivisorItem(5, "Buzz");
            FBDivisorItem fb15 = new FBDivisorItem(15, "FizzBuzz");
            List<IFBItem> fbitems = new List<IFBItem>();
            fbitems.Add(fb3);
            fbitems.Add(fb5);
            fbitems.Add(fb15);
            FBProcessor fbproc = new FBProcessor(numbers, fbitems);
            return fbproc.GetResults();
        }
        private static FBResult[] ProcessResultsFizzAndPalindrome()
        {
            FBDivisorItem fb3 = new FBDivisorItem(3, "Fizz");
            FBPalindromeItem fbp = new FBPalindromeItem(10);
            List<IFBItem> fbitems = new List<IFBItem>();
            fbitems.Add(fb3);
            fbitems.Add(fbp);
            FBProcessor fbproc = new FBProcessor(numbers, fbitems);
            return fbproc.GetResults();
        }
        private static FBResult[] ProcessResultsOutsideAssemblyPalindrome()
        {

            PalindromeOutside op = new PalindromeOutside(10);
            List<IFBItem> fbitems = new List<IFBItem>();
            fbitems.Add(op);
            FBProcessor fbproc = new FBProcessor(numbers, fbitems);
            return fbproc.GetResults();
        }
        #endregion

        
    }
}
