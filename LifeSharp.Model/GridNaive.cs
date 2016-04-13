using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeSharp.Model
{
    public class GridNaive : Grid
    {
        public GridNaive(int height, int width, bool randomize, BoundaryConditions boundaryConditions)
            : base(height, width, randomize, boundaryConditions)
        {
            LiveNeighbourCounts = new int[height, width];
            UpdateNeighbourCounts();
        }

        public GridNaive(int[,] cells, BoundaryConditions boundaryConditions)
            : base(cells, boundaryConditions)
        {
            LiveNeighbourCounts = new int[Height, Width];
            UpdateNeighbourCounts();
        }

        protected override void UpdateNeighbourCounts()
        {
            switch (_boundaryConditions)
            {
                case BoundaryConditions.Zeros:
                    UpdateNeighbourCountsZeros();
                    break;
                case BoundaryConditions.Ones:
                    throw new NotImplementedException();
                case BoundaryConditions.Periodic:
                    throw new NotImplementedException();
                default:
                    throw new ArgumentException();
            }
        }

        private void UpdateNeighbourCountsZeros()
        {
            for (int row = 0; row < Height; row++)
            {
                for (int col = 0; col < Width; col++)
                {
                    int liveNeighbourCount = 0;
                    for (int neighbourRow = row - 1; neighbourRow <= row + 1; neighbourRow++)
                    {
                        for (int neighbourCol = col - 1; neighbourCol <= col + 1; neighbourCol++)
                        {
                            // If neighbour cell is outside boundaries, or neighbour cell is same as cell
                            if (neighbourRow < 0 || neighbourRow >= Height ||
                                neighbourCol < 0 || neighbourCol >= Width ||
                                (neighbourRow == row && neighbourCol == col))
                            {
                                continue;
                            }
                            if (Cells[neighbourRow, neighbourCol] == 1)
                            {
                                liveNeighbourCount++;
                            }
                        }
                    }
                    LiveNeighbourCounts[row, col] = liveNeighbourCount;
                }
            }
        }
    }
}
