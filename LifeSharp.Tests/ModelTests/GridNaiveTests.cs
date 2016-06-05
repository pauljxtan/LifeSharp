using Microsoft.VisualStudio.TestTools.UnitTesting;

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

            CollectionAssert.AreEqual(expectedLiveNeighbourCounts, actualLiveNeighbourCounts);
        }
    }
}