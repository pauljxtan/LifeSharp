﻿using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using LifeSharp.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace LifeSharp.ViewModel
{
    /// <summary>
    /// Encapsulates an Automaton object and exposes the universe for the View to bind to.
    /// </summary>
    public class UniverseViewModel : ViewModelBase
    {
        private static UniverseViewModel _instance = new UniverseViewModel();
        private Automaton _automaton;
        private int _age;
        private int _numEvolutionsToDo;
        private int _delayBetweenEvolutions;
        private bool _automatonIsSet;

        private ObservableCollection<ObservableCollection<int>> _universeCollection;

        public UniverseViewModel()
        {
            AutomatonIsSet = false;
        }

        public bool AutomatonIsSet
        {
            get
            {
                return _automatonIsSet;
            }
            set
            {
                _automatonIsSet = value;
                RaisePropertyChanged("AutomatonIsSet");
            }
        }

        public static UniverseViewModel Instance
        {
            get
            {
                return _instance;
            }
        }

        public Automaton Automaton
        {
            get
            {
                return _automaton;
            }
            set
            {
                _automaton = value;
                AutomatonIsSet = true;
                Age = _automaton.Age;
                UniverseCollection = _automaton.UniverseCollection;
                RaisePropertyChanged("Automaton");
            }
        }

        public int Age
        {
            get
            {
                return _age;
            }
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException();
                _age = value;
                RaisePropertyChanged("Age");
            }
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
                RaisePropertyChanged("NumEvolutions");
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
                RaisePropertyChanged("DelayBetweenEvolutions");
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
                RaisePropertyChanged("UniverseCollection");
            }
        }

        public ICommand EvolveCommand
        {
            get
            {
                return new RelayCommand(Evolve);
            }
        }

        public ICommand ResetCommand
        {
            get
            {
                return new RelayCommand(Reset);
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
            Age++;
            UniverseCollection = _automaton.UniverseCollection;
        }

        private void Reset()
        {
            _automaton.Reset();
            Age = 0;
            UniverseCollection = _automaton.UniverseCollection;
        }
    }
}
