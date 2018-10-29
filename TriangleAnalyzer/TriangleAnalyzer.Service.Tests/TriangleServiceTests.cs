using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TriangleAnalyzer.Service.Interfaces;
using TriangleAnalyzer.Tests;

namespace TriangleAnalyzer.Service.Tests
{
    [TestClass]
    public class TriangleServiceTests : TestBase
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Length of the two shorter sides must be at least longer than the longest.")]
        public void AnalyseAssertInvalidTriangle()
        {
            var service = this.GetService<ITriangleService>();

            var sides = new int[3] { 3, 1, 1 };
            
            service.Analyze(sides);           
        }

        [TestMethod]
        public void AssertEquilateral()
        {
            var service = this.GetService<ITriangleService>();

            var sides = new int[3] { 1, 1, 1 }; ;

            var result = service.Analyze(sides);

            Assert.IsTrue(result == Enums.TriangleType.Equilateral);
        }
    }
}
