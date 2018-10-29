using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TriangleAnalyzer.Service.Enums;
using TriangleAnalyzer.Service.Interfaces.Infrastructure.Queues;
using TriangleAnalyzer.Service.Interfaces.Infrastructure.Repositories;
using TriangleAnalyzer.Service.Model.Core;

namespace TriangleAnalyzer.Infrastructure.Queues
{
    public class TriangleMessageQueue : ITriangleMessageQueue
    {
        public ITriangleStageRepository _triangleStageRepository;
        
        public TriangleMessageQueue(ITriangleStageRepository triangleStageRepository)
        {
            _triangleStageRepository = triangleStageRepository;
        }

        public void ProcessTriangle(int[] sides, TriangleType triangleType)
        {
            var stageItem = new TriangleStageItem { Sides = sides, Processed = false, TriangleType = triangleType };

            _triangleStageRepository.StageItem(stageItem);
        }
    }
}
