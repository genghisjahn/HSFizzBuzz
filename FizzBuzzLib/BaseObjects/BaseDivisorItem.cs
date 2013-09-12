using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzzLib.BaseObjects
{
    public abstract class BaseDivisorItem
    {
        
        public BaseDivisorItem(int divisor,string message,int ordercheck)
        {
            this.Divisor = divisor;
            this.Message = message;
            this.OrderCheck = ordercheck;
        }
        public int Divisor { get;private set; }
        public string Message { get; private set; }
        public int OrderCheck { get; private set; }
    }
}
