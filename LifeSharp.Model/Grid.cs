using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeSharp.Model
{
    /// <summary>
    /// The base abstract class for a grid of cells in a cellular automaton.
    /// </summary>
    public abstract class Grid
    {
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
        public int[,] Cells { get; }

        /// <summary>
        /// Constructs a grid of a given height and width, with all cells initialized to zero.
        /// </summary>
        /// <param name="height">The height of the grid, i.e., the number of rows.</param>
        /// <param name="width">The width of the grid, i.e., the number of columns.</param>
        public Grid(int height, int width)
        {
            Height = height;
            Width = width;
            Cells = new int[height, width];
        }

        /// <summary>
        /// Constructs a grid with an initial configuration.
        /// </summary>
        /// <param name="cells">The initial configuration of the grid.</param>
        public Grid(int[,] cells)
        {
            Height = cells.GetLength(0);
            Width = cells.GetLength(1);
            Cells = new int[Height, Width];
            for (int row = 0; row < Height; row++)
            {
                for (int col = 0; col < Width; col++)
                {
                    Cells[row, col] = cells[row, col];
                }
            }
        }

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
        public abstract void Evolve();
    }
}
