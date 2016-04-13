using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// TODO: Set convolution boundary conditions in constructor
// TODO: Choose grid type (or only use convolution)?

namespace LifeSharp.Model
{
    /// <summary>
    /// A cellular automaton based on Conway's Game of Life.
    /// </summary>
    public class Automaton
    {
        /// <summary>
        /// Computation methods.
        /// </summary>
        public enum ComputeMethod { Naive, Convolution }

        /// <summary>
        /// The age of the automaton, i.e., the number of past evolutions.
        /// </summary>
        public int Age { get; private set; }

        // TODO: Maybe use ObservableCollection from the start instead of int[,]
        public ObservableCollection<ObservableCollection<int>> UniverseCollection
        {
            get
            {
                return Utils.ConvertArrayToCollection(Universe);
            }
        }

        /// <summary>
        /// The universe of the automaton represented as a 2-D grid.
        /// </summary>
        public int[,] Universe {
            get
            {
                return _universe.Cells;
            }
        }

        /// <summary>
        /// A string representation of the universe.
        /// </summary>
        public string UniverseString
        {
            get
            {
                return _universe.GetCellsAsString();
            }
        }

        /// <summary>
        /// The universe grid.
        /// </summary>
        private Grid _universe;

        /// <summary>
        /// Constructs an Automaton of a given size, with all cells initialized to zero by default.
        /// </summary>
        /// <param name="height">The height (i.e. number of rows) of the grid.</param>
        /// <param name="width">The width (i.e. number of rows) of the grid.</param>
        /// <param name="randomize">Whether to randomize the initial seed.</param>
        /// <param name="boundaryConditions">The boundary conditions to be applied.</param>
        /// <param name="computeMethod">The computation method to be used.</param>
        public Automaton(int height, int width, bool randomize = false, BoundaryConditions boundaryConditions = BoundaryConditions.Zeros,
                         ComputeMethod computeMethod = ComputeMethod.Convolution)
        {
            Age = 0;
            switch (computeMethod) {
                case ComputeMethod.Naive:
                    //_universe = new GridNaive(height, width, randomize, boundaryConditions);
                    break;
                    throw new NotImplementedException();
                case ComputeMethod.Convolution:
                    _universe = new GridConvolution(height, width, randomize, boundaryConditions);
                    break;
                default:
                    throw new ArgumentException();
            }
        }

        /// <summary>
        /// Constructs an Automaton with a given seed.
        /// </summary>
        /// <param name="cells">The seed for the automaton.</param>
        /// <param name="boundaryConditions">The boundary conditions to be applied.</param>
        /// <param name="computeMethod">The computation method to be used.</param>
        public Automaton(int[,] cells, BoundaryConditions boundaryConditions = BoundaryConditions.Zeros,
            ComputeMethod computeMethod = ComputeMethod.Convolution)
        {
            Age = 0;
            switch (computeMethod) {
                case ComputeMethod.Naive:
                    //_universe = new GridNaive(height, width, randomize, boundaryConditions);
                    break;
                    throw new NotImplementedException();
                case ComputeMethod.Convolution:
                    _universe = new GridConvolution(cells, boundaryConditions);
                    break;
                default:
                    throw new ArgumentException();
            }
        }

        /// <summary>
        /// Performs a single evolution of the automaton.
        /// </summary>
        public void Evolve()
        {
            _universe.Evolve();
            Age++;
        }
    }
}
