using LifeSharp.Model;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LifeSharp.ViewModel
{
    /// <summary>
    /// Encapsulates an Automaton object and exposes the universe for the View to bind to.
    /// </summary>
    public class AutomatonViewModel : ObservableObject
    {
        private readonly Automaton _automaton;
        private int _age;
        private int _numEvolutionsToDo;
        private int _delayBetweenEvolutions;
        private string _universeString;
        private ObservableCollection<ObservableCollection<int>> _universeCollection;

        public AutomatonViewModel()
        {
            // For debugging only; should be specified by user (or default to zero)
            int[,] seed = 
            {
                { 0, 1, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 1, 0, 0, 0, 0, 0, 0, 0 },
                { 1, 1, 1, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
            };

            _automaton = new Automaton(seed);
            UniverseString = _automaton.UniverseString;
            UniverseCollection = _automaton.UniverseCollection;
            NumEvolutionsToDo = 1;
        }

        public int NumEvolutionsToDo
        {
            get
            {
                return _numEvolutionsToDo;
            }
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException();
                _numEvolutionsToDo = value;
                RaisePropertyChangedEvent("NumEvolutions");
            }
        }

        public int DelayBetweenEvolutions
        {
            get
            {
                return _delayBetweenEvolutions;
            }
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException();
                _delayBetweenEvolutions = value;
                RaisePropertyChangedEvent("DelayBetweenEvolutions");
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

        public ICommand ResetCommand
        {
            get
            {
                return new DelegateCommand(Reset);
            }
        }

        private async Task<bool> ExecuteWithDelay(Action action, int delay)
        {
            await Task.Delay(delay);
            action();
            return true;
        }

        private async void Evolve()
        {
            EvolveOnce();
            for (int i = 1; i < _numEvolutionsToDo; i++)
            {
                await ExecuteWithDelay(EvolveOnce, _delayBetweenEvolutions);
            }
        }

        private void EvolveOnce()
        {
            _automaton.Evolve();
            UniverseString = _automaton.UniverseString;
            UniverseCollection = _automaton.UniverseCollection;
        }

        private void Reset()
        {
            _automaton.Reset();
            UniverseString = _automaton.UniverseString;
            UniverseCollection = _automaton.UniverseCollection;
        }
    }
}
