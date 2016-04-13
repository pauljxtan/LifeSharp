using System;

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

        public GridConvolution(int height, int width, bool randomize, BoundaryConditions boundaryConditions = BoundaryConditions.Zeros)
            : base(height, width, randomize, boundaryConditions)
        {
        }

        public GridConvolution(int[,] cells, BoundaryConditions boundaryConditions) : base(cells, boundaryConditions)
        {
        }

        protected override void UpdateNeighbourCounts()
        {
            LiveNeighbourCounts = Convolution2D.Convolve(Cells, _kernel, _boundaryConditions);
        }
    }
}
