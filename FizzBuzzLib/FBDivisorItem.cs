using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FizzBuzzLib.Interfaces;
using FizzBuzzLib.BaseObjects;
namespace FizzBuzzLib
{
    public class FBDivisorItem:BaseDivisorItem,IFBItem
    {
        public FBDivisorItem(int i, string  msg, int ocheck=0  ):base(i,msg,ocheck)
        {
           
        }
        public FBResult GetResult(int i)
        {
            FBResult result = new FBResult(i,null);
            if (i % this.Divisor == 0)
            {
                result.FBValue = i;
                result.Text = this.Message;
            }
            return result;
        }
    }
}
