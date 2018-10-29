using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TriangleAnalyzer.Service.Enums;
using TriangleAnalyzer.Service.Model;

namespace TriangleAnalyzer.Service.Interfaces
{
    public interface ITriangleService
    {
        TriangleType Analyze(int[] sides);
        IEnumerable<Triangle> GetAll();
    }
}
