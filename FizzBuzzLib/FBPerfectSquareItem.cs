using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FizzBuzzLib.Interfaces;
namespace FizzBuzzLib
{
    public class FBPerfectSquareItem:IFBItem
    {
        public FBPerfectSquareItem(int ordercheck)
        {
            this.OrderCheck = ordercheck;
        }
        public FBResult GetResult(int i)
        {
            FBResult result = new FBResult(i, null);
            double root = Math.Sqrt(i);
            bool isSquare = root % 1 == 0;
            if (isSquare) result.Text = "Perfect Square!";
            return result;
        }

        public int OrderCheck{get;private set;}
      
    }
}
