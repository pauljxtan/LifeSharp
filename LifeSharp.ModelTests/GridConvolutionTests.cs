using Microsoft.VisualStudio.TestTools.UnitTesting;
using LifeSharp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeSharp.Model.Tests
{
    [TestClass()]
    public class GridConvolutionTests
    {
        [TestMethod()]
        public void EvolveTest()
        {
            // Test a glider
            int[,] cells =
            {
                { 0, 1, 0, 0 },
                { 0, 0, 1, 0 },
                { 1, 1, 1, 0 },
                { 0, 0, 0, 0 },
            };

            int[,] expected =
            {
                { 0, 0, 0, 0 },
                { 1, 0, 1, 0 },
                { 0, 1, 1, 0 },
                { 0, 1, 0, 0 },
            };

            var grid = new GridConvolution(cells);
            grid.Evolve();

            CollectionAssert.AreEqual(expected, grid.Cells);
        }
    }
}