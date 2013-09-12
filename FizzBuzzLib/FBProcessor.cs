using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FizzBuzzLib.Interfaces;
namespace FizzBuzzLib
{
    public class FBProcessor
    {
        List<IFBItem> fbitems;
        int[] nums;
        public FBProcessor(int[] nums, List<IFBItem> fbitems)
        {
            this.fbitems=fbitems;
            this.nums=nums;
        }
        public FBResult[] GetResults()
        {
            var result = new FBResult[this.nums.Length];
            for (int i = 0; i < this.nums.Length;i++ )
            {
                foreach (var fbi in fbitems.OrderByDescending(fb=>fb.OrderCheck))
                {
                    FBResult fbresult = fbi.GetResult(nums[i]);
                    result[i] = fbresult;
                    if (fbresult.Text!=null)
                    {
                        break;
                    }
                }
            }
            return result;
        }
    }
}
