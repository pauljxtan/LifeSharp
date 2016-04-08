using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeSharp.Model
{
    public abstract class Grid
    {
        public int Width { get; }
        public int Height { get; }
        public int[,] Cells { get; }

        public Grid(int width, int height)
        {
            Width = width;
            Height = height;
            Cells = new int[height, width];
        }

        /* Initialize grid with array */
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

        /* Read preset seed from text file */
        public Grid(String filePath)
        {
            throw new NotImplementedException();
        }

        /*
        public void toggleCellState(int x, int y)
        {
            Cells[x, y] = Math.Abs(Cells[x, y] - 1);
        }
        */

        public abstract void Evolve();
    }
}
