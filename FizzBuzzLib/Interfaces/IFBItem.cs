using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzzLib.Interfaces
{
    public interface IFBItem
    {
        int OrderCheck { get; set; }
        FBResult GetResult(int i);
    }
}
