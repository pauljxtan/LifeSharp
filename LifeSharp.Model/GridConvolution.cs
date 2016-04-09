using System;
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
        private int[,] liveNeighbourCounts;

        /// <summary>
        /// Constructs a grid of a given height and width, with all cells initialized to zero.
        /// </summary>
        /// <param name="height">The height of the grid, i.e., the number of rows.</param>
        /// <param name="width">The width of the grid, i.e., the number of columns.</param>
        public GridConvolution(int height, int width) : base(height, width)
        {
            UpdateNeighbourCounts();
        }


        /// <summary>
        /// Constructs a grid with an initial configuration.
        /// </summary>
        /// <param name="cells">The initial configuration of the grid.</param>
        public GridConvolution(int[,] cells) : base(cells)
        {
            UpdateNeighbourCounts();
        }

        /// <summary>
        /// Updates the live neighbour counts for all cells.
        /// </summary>
        private void UpdateNeighbourCounts()
        {
            liveNeighbourCounts = Convolution2D.Convolve(Cells, _kernel);
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
                    liveNeighbourCount = liveNeighbourCounts[row, col];
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
