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
        public int[,] Universe { get; private set; }

        /// <summary>
        /// A string representation of the universe.
        /// </summary>
        public string UniverseString
        {
            get
            {
                return _universeGrid.GetCellsAsString();
            }
        }

        /// <summary>
        /// An intermediate representation of the universe grid for encapsulation purposes.
        /// </summary>
        private Grid _universeGrid;

        /// <summary>
        /// Constructs an Automaton of a given size, with all cells initialized to zero by default.
        /// </summary>
        /// <param name="height">The height (i.e. number of rows) of the grid.</param>
        /// <param name="width">The width (i.e. number of rows) of the grid.</param>
        /// <param name="randomize">Whether to randomize the initial seed.</param>
        public Automaton(int height, int width, bool randomize = false)
        {
            Age = 0;
            _universeGrid = new GridConvolution(width, height, randomize);
            Universe = _universeGrid.Cells;
        }

        /// <summary>
        /// Constructs an Automaton with a given seed.
        /// </summary>
        /// <param name="cells">The seed for the automaton.</param>
        public Automaton(int[,] cells)
        {
            Age = 0;
            _universeGrid = new GridConvolution(cells);
            Universe = _universeGrid.Cells;
        }

        /// <summary>
        /// Performs a single evolution of the automaton.
        /// </summary>
        public void Evolve()
        {
            _universeGrid.Evolve();
            Universe = _universeGrid.Cells;
            Age++;
        }
    }
}
