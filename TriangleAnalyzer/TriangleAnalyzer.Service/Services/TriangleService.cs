using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TriangleAnalyzer.Service.Enums;
using TriangleAnalyzer.Service.Interfaces;
using TriangleAnalyzer.Service.Interfaces.Infrastructure;
using TriangleAnalyzer.Service.Interfaces.Infrastructure.Queues;
using TriangleAnalyzer.Service.Model;

namespace TriangleAnalyzer.Service.Services
{
    public class TriangleService : ITriangleService
    {
        ITriangleRepository _triangleRepository;
        ITriangleMessageQueue _triangleMessageQueue;

        public TriangleService(ITriangleRepository repository, ITriangleMessageQueue triangleMessageQueue)
        {
            _triangleRepository = repository;
            _triangleMessageQueue = triangleMessageQueue;
        }

        public TriangleType Analyze(int[] sides)
        {
            var triagleType = TriangleType.NotSet;

            ValidateTriangle(sides);

            //if all sides are equal
            if(sides[0] == sides[1] && sides[1] == sides[2])
            {
                triagleType = TriangleType.Equilateral;
            }            
            //if two sides are equal
            else if (sides[0] == sides[1] || sides[0] == sides[2] || sides[1] == sides[2])
            {
                triagleType = TriangleType.Isosceles;
            }
            else
            {
                triagleType = TriangleType.Scalene;
            }

            //Offload to queue
            _triangleMessageQueue.ProcessTriangle(sides, triagleType);

            return triagleType;
        }

        public IEnumerable<Triangle> GetAll()
        {
            return _triangleRepository.GetAll();
        }

        private void ValidateTriangle(int[] sides)
        {
            //Count must be 3
            if (sides.Length != 3)
            {
                throw new ArgumentException("Shape does not have three sides. Not a valid triangle.");                
            }

            var sortedSides = sides.OrderByDescending(s => s).ToArray();

            //All side lengths must be positive
            if (sortedSides[2] <= 0)
            {
                throw new ArgumentException("All side lengths must be positive. Not a valid triangle.");
            }

            //Length of the two shorter sides must be at least longer than the longest
            if((sortedSides[2] + sortedSides[1]) > sortedSides[0])
            {
                throw new ArgumentException("Length of the two shorter sides must be at least longer than the longest.");
            }            
        }
    }
}
