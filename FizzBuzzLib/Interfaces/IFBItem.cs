﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzzLib.Interfaces
{
    public interface IFBItem
    {
        FBResult GetResult(int i);
        int OrderCheck{get;}
    }
}
