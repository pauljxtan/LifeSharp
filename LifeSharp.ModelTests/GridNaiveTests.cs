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
    public class GridNaiveTests
    {
        [TestMethod()]
        public void GridNaiveWithSeedTest()
        {
            int[,] seed =
            {
                { 0, 1, 0, 0 },
                { 0, 0, 1, 0 },
                { 1, 1, 1, 0 },
                { 0, 0, 0, 0 },
            };

            var grid = new GridNaive(seed, BoundaryConditions.Zeros);

            int[,] expectedCells =
            {
                { 0, 1, 0, 0 },
                { 0, 0, 1, 0 },
                { 1, 1, 1, 0 },
                { 0, 0, 0, 0 }
            };

            int[,] actualCells = grid.Cells;

            CollectionAssert.AreEqual(expectedCells, actualCells);

            int[,] expectedLiveNeighbourCounts =
            {
                { 1, 1, 2, 1 },
                { 3, 5, 3, 2 },
                { 1, 3, 2, 2 },
                { 2, 3, 2, 1 }
            };

            int[,] actualLiveNeighbourCounts = grid.LiveNeighbourCounts;

            Console.WriteLine(grid.LiveNeighbourCounts[0, 0] + " " + grid.LiveNeighbourCounts[0, 1] + " " + grid.LiveNeighbourCounts[0, 2] + " " + grid.LiveNeighbourCounts[0, 3]);
            Console.WriteLine(grid.LiveNeighbourCounts[1,0] + " " + grid.LiveNeighbourCounts[1,1] + " " + grid.LiveNeighbourCounts[1,2] + " " + grid.LiveNeighbourCounts[1, 3]);
            Console.WriteLine(grid.LiveNeighbourCounts[2,0] + " " + grid.LiveNeighbourCounts[2,1] + " " + grid.LiveNeighbourCounts[2,2] + " " + grid.LiveNeighbourCounts[2, 3]);
            Console.WriteLine(grid.LiveNeighbourCounts[3,0] + " " + grid.LiveNeighbourCounts[3,1] + " " + grid.LiveNeighbourCounts[3,2] + " " + grid.LiveNeighbourCounts[3, 3]);

            CollectionAssert.AreEqual(expectedLiveNeighbourCounts, actualLiveNeighbourCounts);
        }
    }
}