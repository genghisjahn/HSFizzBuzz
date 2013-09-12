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


        public int? FBValue{get;set;}
        public string Text { get; set; }
        public override string ToString()
        {
            if (this.FBValue.HasValue)return this.FBValue.Value.ToString();

            if (this.Text != null) return this.Text;
            throw new NullReferenceException("This instance was not set correctly.");
        }
    }
}
