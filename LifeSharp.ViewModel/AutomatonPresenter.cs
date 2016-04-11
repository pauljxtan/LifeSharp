using LifeSharp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LifeSharp.ViewModel
{
    /// <summary>
    /// Encapsulates an Automaton object and exposes the universe for the View to bind to.
    /// </summary>
    public class AutomatonPresenter : ObservableObject
    {
        private int[,] _universe;
        private string _universeString;
        private ObservableCollection<ObservableCollection<int>> _universeCollection;
        private readonly Automaton _automaton;

        public AutomatonPresenter()
        {
            // For debugging only; should be specified by user (or default to zero)
            int[,] seed = 
            {
                { 0, 1, 0, 0, 0, 0, 0 },
                { 0, 0, 1, 0, 0, 0, 0 },
                { 1, 1, 1, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0 },
            };

            _automaton = new Automaton(seed);
            _universe = _automaton.Universe;
            _universeString = _automaton.UniverseString;
            _universeCollection = _automaton.UniverseCollection;
        }

        public int[,] Universe
        {
            get
            {
                return _universe;
            }
            private set
            {
                // TODO: check if actually changed?
                _universe = value;
                RaisePropertyChangedEvent("Universe");
            }
        }

        public string UniverseString
        {
            get
            {
                return _universeString;
            }
            private set
            {
                _universeString = value;
                RaisePropertyChangedEvent("UniverseString");
            }
        }

        public ObservableCollection<ObservableCollection<int>> UniverseCollection
        {
            get
            {
                return _universeCollection;
            }
            private set
            {
                _universeCollection = value;
                RaisePropertyChangedEvent("UniverseCollection");
            }
        }

        public ICommand EvolveCommand
        {
            get
            {
                return new DelegateCommand(Evolve);
            }
        }

        private void Evolve()
        {
            _automaton.Evolve();
            Universe = _automaton.Universe;
            UniverseString = _automaton.UniverseString;
            UniverseCollection = _automaton.UniverseCollection;
        }
    }
}
