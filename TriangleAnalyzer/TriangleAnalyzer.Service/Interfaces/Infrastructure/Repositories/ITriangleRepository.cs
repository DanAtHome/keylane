using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TriangleAnalyzer.Service.Model;

namespace TriangleAnalyzer.Service.Interfaces.Infrastructure
{
    public interface ITriangleRepository
    {
       IEnumerable<Triangle> GetAll();
    }
}
