using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TriangleAnalyzer.Infrastructure.Context;
using TriangleAnalyzer.Service.Interfaces.Infrastructure;
using TriangleAnalyzer.Service.Model;

namespace TriangleAnalyzer.Infrastructure.Repositories
{
    public class TriangleRepository : ITriangleRepository
    {
        TriangleAnalyzerDB _context = null;

        public TriangleRepository(TriangleAnalyzerDB context)
        {
            _context = context;
        }

        public IEnumerable<Triangle> GetAll()
        {
            return _context.Triangles.AsEnumerable();
        }

    }
}
