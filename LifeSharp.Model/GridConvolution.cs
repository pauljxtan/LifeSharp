using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeSharp.Model
{
    public class GridConvolution : Grid
    {
        private readonly int[,] kernel =
        {
            { 1, 1, 1 },
            { 1, 0, 1 },
            { 1, 1, 1 }
        };
        private int[,] liveNeighbourCounts;

        public GridConvolution(int width, int height) : base(width, height)
        {
            UpdateNeighbourCounts();
        }

        public GridConvolution(int[,] cells) : base(cells)
        {
            UpdateNeighbourCounts();
        }

        private void UpdateNeighbourCounts()
        {
            liveNeighbourCounts = Convolution2D.Convolve(Cells, kernel);
        }

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
