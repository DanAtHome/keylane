using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TriangleAnalyzer.Service.Enums;

namespace TriangleAnalyzer.Service.Interfaces.Infrastructure.Queues
{
    public interface ITriangleMessageQueue
    {
        void ProcessTriangle(int[] triangle, TriangleType triangleType);
    }
}
