﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TriangleAnalyzer.Service.Enums;

namespace TriangleAnalyzer.Service.Model
{
    public class Triangle
    {
        public int A { get; set; }

        public int B { get; set; }

        public int C { get; set; }

        public TriangleType TriangleType { get; set; }
    }
}