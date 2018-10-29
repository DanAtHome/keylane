using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TriangleAnalyzer.Service.Model.Core;

namespace TriangleAnalyzer.Service.Interfaces.Infrastructure.Repositories
{
    public interface ITriangleStageRepository
    {
        void StageItem(TriangleStageItem stageItem);
    }
}
