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
    public class TriangleStageRepository : ITriangleStageRepository
    {
        TriangleAnalyzerDB _context = null;

        public TriangleStageRepository(TriangleAnalyzerDB context)
        {
            _context = context;
        }

        public void StageItem(TriangleStageItem stageItem)
        {
            _context.TriangleStageItems.Add(stageItem);

            _context.SaveChanges();
        }
    }
}
