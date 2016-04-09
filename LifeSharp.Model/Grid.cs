using System;
using System.Collections.Generic;
using System.IO;
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

        public abstract void Evolve();
    }
}
