using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FizzBuzzLib;
using FizzBuzzLib.Interfaces;
namespace OtherFizzBuzzLib
{
    public class PalindromeOutside:IFBItem
    {
        public PalindromeOutside(int ordercheck)
        {
            this.OrderCheck = ordercheck;
        }
        public FBResult GetResult(int i)
        {
            FBResult result = new FBResult(i, null);
            string normal = i.ToString();
            string backwards = new string(normal.Reverse().ToArray());
            if (normal == backwards)
            {
                result.Text = "Palindrome!";
            }
            return result;
        }

        public int OrderCheck{get;private set;}
        
    }
}
