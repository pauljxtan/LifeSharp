﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LifeSharp.Model.Tests
{
    [TestClass()]
    public class GridConvolutionTests
    {
        [TestMethod()]
        public void GridConvolutionFromSizeTest()
        {
            var grid = new GridConvolution(4, 2, false);

            int[,] expected =
            {
                { 0, 0},
                { 0, 0},
                { 0, 0},
                { 0, 0},
            };

            int[,] actual = grid.Cells;

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GridConvolutionWithSeedTest()
        {
            int[,] seed =
            {
                { 0, 1, 0, 0 },
                { 0, 0, 1, 0 },
                { 1, 1, 1, 0 },
                { 0, 0, 0, 0 },
            };

            var grid = new GridConvolution(seed, BoundaryConditions.Zeros);

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

            var grid = new GridConvolution(cells, BoundaryConditions.Zeros);
            grid.Evolve();

            CollectionAssert.AreEqual(expected, grid.Cells);
        }
    }
}