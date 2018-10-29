using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TriangleAnalyzer.Service.Interfaces.Service;

namespace TriangleAnalyzer.Batch
{
    public class BatchRunner
    {
        private readonly ITriangleProcessService _triangleProcessService;

        public BatchRunner(ITriangleProcessService triangleProcessService)
        {
            _triangleProcessService = triangleProcessService;
        }

        public void Run()
        {
            _triangleProcessService.ProcessTriangles();
        }
    }
}
