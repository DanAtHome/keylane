using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TriangleAnalyzer.Service.Interfaces.Infrastructure;
using TriangleAnalyzer.Tests;
using System.Linq;

namespace TriangleAnalyzer.Infrastructure.Tests
{
    [TestClass]
    public class TriagleRepositoryTests : TestBase
    {
        [TestMethod]
        public void AssertEquilateral()
        {
            var repository = this.GetService<ITriangleRepository>();

            var result = repository.GetAll();

            Assert.IsTrue(result.Any());
        }
    }
}
