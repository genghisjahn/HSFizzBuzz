using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FizzBuzzLib.Interfaces;
namespace FizzBuzzLib
{
    class FBPalindromeItem:IFBItem
    {
        public FBPalindromeItem(int ordercheck)
        {
            this.OrderCheck = ordercheck;
        }

        public FBResult GetResult(int i)
        {
            FBResult result = new FBResult(i, null);
            string normal = i.ToString();
            string backwards = normal.Reverse().ToString();
            if (normal == backwards)
            {
                result.Text = "Palindrome!";
            }
            return result;
        }

        public int OrderCheck { get; private set; }
    }
}
