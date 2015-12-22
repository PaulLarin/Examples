using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeometricFigures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricFigures.Tests
{
    [TestClass()]
    public class RightTriangleTests
    {
        [TestMethod()]
        public void RightTriangleTest_A4B3_AreaIs6()
        {
            var triangle = new RightTriangle(4, 3);

            var area = triangle.Area;

            Assert.IsTrue(area == 6);
        }

        [TestMethod()]
        public void RightTriangleTest_A0B3_AreaIs0()
        {
            var triangle = new RightTriangle(0, 3);

            var area = triangle.Area;

            Assert.IsTrue(area == 0);
        }

        [TestMethod()]
        public void RightTriangleTest_A4B0_AreaIs0()
        {
            var triangle = new RightTriangle(4, 0);

            var area = triangle.Area;

            Assert.IsTrue(area == 0);
        }
    }
}