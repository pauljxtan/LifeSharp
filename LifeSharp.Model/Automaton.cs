using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeSharp.Model
{
    /// <summary>
    /// A cellular automaton based on Conway's Game of Life.
    /// </summary>
    public class Automaton
    {
        /// <summary>
        /// The age of the automaton, i.e., the number of past evolutions.
        /// </summary>
        public int Age { get; private set; }

        /// <summary>
        /// The universe of the automaton represented as a 2-D grid.
        /// </summary>
        public Grid Universe { get; }

        /// <summary>
        /// Constructs an Automaton of a given size, with all cells initialized to zero.
        /// </summary>
        /// <param name="height">The height (i.e. number of rows) of the grid.</param>
        /// <param name="width">The width (i.e. number of rows) of the grid.</param>
        public Automaton(int height, int width)
        {
            Age = 0;
            Universe = new GridConvolution(width, height);
        }

        /// <summary>
        /// Constructs an Automaton with a given seed.
        /// </summary>
        /// <param name="cells">The seed for the automaton.</param>
        public Automaton(int[,] cells)
        {
            Age = 0;
            Universe = new GridConvolution(cells);
        }

        /// <summary>
        /// Performs a single evolution of the automaton.
        /// </summary>
        public void Evolve()
        {
            Universe.Evolve();
            Age++;
        }
    }
}
