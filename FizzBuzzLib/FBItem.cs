using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FizzBuzzLib.Interfaces;
using FizzBuzzLib.BaseObjects;
namespace FizzBuzzLib
{
    public class FBItem:BaseDivisorItem,IFBItem
    {
        public FBItem(int i, string  msg  ):base(i,msg)
        {
           
        }
        
        public int OrderCheck{get;set;}
        public FBResult GetResult(int i)
        {
            FBResult result = new FBResult();
            if (i % this.Divisor == 0)
            {
                result.FBValue = null;
                result.Text = this.Message;
            }
            else
            {
                result.FBValue = i;
                result.Text = null;
            }
            return result;
        }
    }
}
