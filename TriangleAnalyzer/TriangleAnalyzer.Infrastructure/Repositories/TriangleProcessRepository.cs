using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TriangleAnalyzer.Infrastructure.Context;
using TriangleAnalyzer.Service.Interfaces.Infrastructure.Repositories;
using TriangleAnalyzer.Service.Model.Core;

namespace TriangleAnalyzer.Infrastructure.Repositories
{
    public class TriangleProcessRepository : ITriangleProcessRepository
    {
        TriangleAnalyzerDB _context = null;

        public TriangleProcessRepository(TriangleAnalyzerDB context)
        {
            _context = context;
        }

        public void ProcessTriagles()
        {
            while(true)
            {
                var unprocessedTriangle = _context.TriangleStageItems.FirstOrDefault(tsi => !tsi.Processed);

                if(unprocessedTriangle == null)
                {
                    break;
                }

                var sortedSides = unprocessedTriangle.Sides.OrderByDescending(s => s).ToArray();

                if(!TriangleAlreadyExists(sortedSides))
                {
                    _context.Triangles.Add(new Service.Model.Triangle { A = sortedSides[0], B = sortedSides[1], C = sortedSides[2], TriangleType = unprocessedTriangle.TriangleType });                    
                }

                unprocessedTriangle.Sides = sortedSides;

                _context.SaveChanges();
            }           
        }

        public bool TriangleAlreadyExists(int[] sides)
        {
            return _context.TriangleStageItems.Any(tsi => tsi.Processed && sides[0] == tsi.Sides[0]
            && sides[1] == tsi.Sides[1]
            && sides[2] == tsi.Sides[2]);
        }
    }
}
