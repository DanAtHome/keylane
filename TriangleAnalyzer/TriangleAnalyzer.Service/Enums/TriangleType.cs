﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleAnalyzer.Service.Enums
{
    public enum TriangleType
    {
        NotSet = 0,
        Scalene = 1, // no two sides are the same length
        Isosceles = 2, // two sides are the same length and one differs
        Equilateral = 3 // all sides are the same length  
    }
}
