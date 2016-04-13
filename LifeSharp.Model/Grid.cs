using System;

namespace LifeSharp.Model
{
    /// <summary>
    /// The available computation methods.
    /// </summary>
    public enum ComputeMethod { Naive, Convolution }

    /// <summary>
    /// The base abstract class for a grid of cells in a cellular automaton.
    /// </summary>
    public abstract class Grid
    {
        /// <summary>
        /// The boundary conditions for the grid.
        /// </summary>
        protected readonly BoundaryConditions _boundaryConditions;

        /// <summary>
        /// A record of the initial grid.
        /// </summary>
        private readonly int[,] _cellsInitial;


        /// <summary>
        /// Constructs a grid of a given size, with all cells initialized to zero by default.
        /// </summary>
        /// <param name="height">The height (i.e. number of rows) of the grid.</param>
        /// <param name="width">The width (i.e. number of rows) of the grid.</param>
        /// <param name="randomize">Whether to randomize the initial seed.</param>
        /// <param name="boundaryConditions">The boundary conditions to be applied.</param>
        public Grid(int height, int width, bool randomize, BoundaryConditions boundaryConditions)
        {
            Height = height;
            Width = width;
            _boundaryConditions = boundaryConditions;
            Cells = new int[height, width];

            if (randomize)
            {
                Random randomGenerator = new Random();

                for (int row = 0; row < height; row++)
                {
                    for (int col = 0; col < width; col++)
                    {
                        Cells[row, col] = randomGenerator.Next(0, 2);
                    }
                }
            }
            _cellsInitial = Utils.GetArrayDeepCopy(Cells);
            UpdateNeighbourCounts();
        }

        /// <summary>
        /// Constructs a grid with an initial configuration.
        /// </summary>
        /// <param name="cells">The initial configuration of the grid.</param>
        /// <param name="boundaryConditions">The boundary conditions to be applied.</param>
        public Grid(int[,] cells, BoundaryConditions boundaryConditions)
        {
            Height = cells.GetLength(0);
            Width = cells.GetLength(1);
            _boundaryConditions = boundaryConditions;
            Cells = new int[Height, Width];
            for (int row = 0; row < Height; row++)
            {
                for (int col = 0; col < Width; col++)
                {
                    Cells[row, col] = cells[row, col];
                }
            }
            _cellsInitial = Utils.GetArrayDeepCopy(Cells);
            UpdateNeighbourCounts();
        }

        /// <summary>
        /// The height of the grid, i.e., the number of rows.
        /// </summary>
        public int Height { get; }

        /// <summary>
        /// The width of the grid, i.e. the number of columns.
        /// </summary>
        public int Width { get; }

        /// <summary>
        /// The cells in the grid, represented by 0s and 1s.
        /// </summary>
        public int[,] Cells { get; private set; }

        /// <summary>
        /// The number of live neighbours of each cell.
        /// </summary>
        public int[,] LiveNeighbourCounts { get; protected set; }

        /// <summary>
        /// Returns a string representation of the grid.
        /// </summary>
        /// <returns>A string representation of the grid.</returns>
        public string GetCellsAsString()
        {
            string str = "";

            for (int row = 0; row < Height; row++)
            {
                for (int col = 0; col < Width; col++)
                {
                    str += Cells[row, col] + " ";
                }
                str += "\n";
            }

            return str;
        }

        /// <summary>
        /// Performs a single evolution of the grid.
        /// </summary>
        public void Evolve()
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

        /// <summary>
        /// Resets the grid to its initial state.
        /// </summary>
        public void Reset()
        {
            Cells = Utils.GetArrayDeepCopy(_cellsInitial);
            UpdateNeighbourCounts();
        }


        /// <summary>
        /// Updates the live neighbour counts for all cells.
        /// </summary>
        protected abstract void UpdateNeighbourCounts();
    }
}
