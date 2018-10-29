using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TriangleAnalyzer.Service.Interfaces.Infrastructure.Repositories;
using TriangleAnalyzer.Service.Interfaces.Service;

namespace TriangleAnalyzer.Service.Services
{
    public class TriangleProcessService : ITriangleProcessService
    {
        ITriangleProcessRepository _triangleProcessRepository;

        public TriangleProcessService(ITriangleProcessRepository triangleProcessRepository)
        {
            _triangleProcessRepository = triangleProcessRepository;
        }

        public void ProcessTriangles()
        {
            _triangleProcessRepository.ProcessTriagles();
        }
    }
}
