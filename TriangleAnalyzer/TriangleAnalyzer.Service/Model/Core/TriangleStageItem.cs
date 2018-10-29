using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TriangleAnalyzer.Service.Enums;

namespace TriangleAnalyzer.Service.Model.Core
{
    public class TriangleStageItem
    {
        public int[] Sides { get; set; }

        public TriangleType TriangleType { get; set; }

        public bool Processed { get; set; }

        public DateTime? ProcessedDate { get; set; }
    }
}
