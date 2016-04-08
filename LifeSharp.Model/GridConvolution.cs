using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeSharp.Model
{
    public class GridConvolution : Grid
    {
        private int[,] kernel =
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

            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    liveNeighbourCount = liveNeighbourCounts[i, j];
                    // Cell is alive
                    if (Cells[i, j] == 1)
                    {
                        // Less than live 2 neighbours: die by under-population
                        // More than live 3 neighbours: die by over-population
                        if (liveNeighbourCount < 2 || liveNeighbourCount > 3) {
                            Cells[i, j] = 0;
                        }
                        // 2 or 3 live neighbours: live on
                    }
                    // Cell is dead
                    else
                    {
                        // 3 live neighbours: come alive by reproduction
                        if (liveNeighbourCount == 3)
                        {
                            Cells[i, j] = 1;
                        }
                    }
                }
            }

            UpdateNeighbourCounts();
        }
    }
}
