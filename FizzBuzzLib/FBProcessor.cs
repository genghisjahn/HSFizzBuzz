using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzzLib
{
    public class FBProcessor
    {
        List<FBItem> fbitems;
        int[] nums;
        public FBProcessor(int[] nums, List<FBItem> fbitems)
        {
            this.fbitems = fbitems;
            this.nums=nums;
        }
        public FBResult[] GetResults()
        {
            var result = new FBResult[this.nums.Length];
            for (int i = 0; i <= this.nums.Length;i++ )
            {
                foreach (var fbi in fbitems)
                {
                    FBResult fbresult = fbi.GetResult(nums[i]);
                    result[i] = fbresult;
                    if (fbresult.Text.Length > 0)
                    {
                        break;
                    }
                }
            }
            return result;
        }
    }
}
