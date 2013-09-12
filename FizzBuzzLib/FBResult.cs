using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzzLib
{
    public class FBResult
    {
        public FBResult() { }
        public FBResult(int? value, string text)
        {
            this.FBValue = value;
            this.Text = text;
        }


        public int? FBValue { get; set; }
        public string Text { get; set; }
        public override string ToString()
        {
            if(this.FBValue.HasValue==false){
                throw new NullReferenceException("This instance was not set correctly.");
            }
            string result = "";
            string msg = "";
            if (this.Text != null)
            {
                msg = this.Text;
            }
            else
            {
                 msg = this.FBValue.Value.ToString();
            }
            result = string.Format("{0} - {1}", this.FBValue.Value, msg);
            return result;
        }
    }
}
