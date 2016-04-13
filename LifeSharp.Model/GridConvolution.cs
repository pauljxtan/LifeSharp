﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeSharp.Model
{
    /// <summary>
    /// A cellular automaton grid that determines live neighbours via image convolution.
    /// </summary>
    public class GridConvolution : Grid
    {
        /// <summary>
        /// The convolution kernel for computing the number of live neighbours of each cell.
        /// </summary>
        private readonly int[,] _kernel =
        {
            { 1, 1, 1 },
            { 1, 0, 1 },
            { 1, 1, 1 }
        };

        /// <summary>
        /// The number of live neighbours of each cell.
        /// </summary>
        public int[,] LiveNeighbourCounts { get; private set; }

        /// <summary>
        /// Constructs a grid of a given size, with all cells initialized to zero by default.
        /// </summary>
        /// <param name="height">The height (i.e. number of rows) of the grid.</param>
        /// <param name="width">The width (i.e. number of rows) of the grid.</param>
        /// <param name="randomize">Whether to randomize the initial seed.</param>
        /// <param name="boundaryConditions">The boundary conditions for convolution.</param>
        public GridConvolution(int height, int width, bool randomize, BoundaryConditions boundaryConditions = BoundaryConditions.Zeros)
            : base(height, width, randomize, boundaryConditions)
        {
            UpdateNeighbourCounts();
        }


        /// <summary>
        /// Constructs a grid with an initial configuration.
        /// </summary>
        /// <param name="cells">The initial configuration of the grid.</param>
        /// <param name="boundaryConditions">The boundary conditions for convolution.</param>
        public GridConvolution(int[,] cells, BoundaryConditions boundaryConditions) : base(cells, boundaryConditions)
        {
            UpdateNeighbourCounts();
        }

        /// <summary>
        /// Updates the live neighbour counts for all cells.
        /// </summary>
        private void UpdateNeighbourCounts()
        {
            // TODO: send boundary conditions to convolution method
            LiveNeighbourCounts = Convolution2D.Convolve(Cells, _kernel, _boundaryConditions);
        }

        /// <summary>
        /// Performs a single evolution of the grid.
        /// </summary>
        public override void Evolve()
        {
            int liveNeighbourCount;

            for (int row = 0; row < Height; row++)
            {
                for (int col = 0; col < Width; col++)
                {
                    liveNeighbourCount = LiveNeighbourCounts[row, col];
                    // Cell is alive
                    if (Cells[row, col] == 1)
                    {
                        // Less than live 2 neighbours: die by under-population
                        // More than live 3 neighbours: die by over-population
                        if (liveNeighbourCount < 2 || liveNeighbourCount > 3) {
                            Cells[row, col] = 0;
                        }
                        // 2 or 3 live neighbours: live on
                    }
                    // Cell is dead
                    else
                    {
                        // 3 live neighbours: come alive by reproduction
                        if (liveNeighbourCount == 3)
                        {
                            Cells[row, col] = 1;
                        }
                    }
                }
            }
            UpdateNeighbourCounts();
        }
    }
}
