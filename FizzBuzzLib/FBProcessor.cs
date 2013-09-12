using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FizzBuzzLib.Interfaces;
using System.ComponentModel;
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
        [Description("FBItems are processed in descending order based on the Order Check property."), Category("Functionality")]
        public FBResult[] GetResults()
        {
            var orderedItems = fbitems.OrderByDescending(fb => fb.OrderCheck);
            var result = new FBResult[this.nums.Length];
            for (int i = 0; i < this.nums.Length;i++ )
            {
                foreach (var fbi in orderedItems)
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
