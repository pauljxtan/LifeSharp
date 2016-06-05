using LifeSharp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LifeSharp.ViewModel
{
    public class Presenter : ObservableObject
    {
        private static int[,] grid = 
        {
            { 0, 1, 0, 0 },
            { 0, 0, 1, 0 },
            { 1, 1, 1, 0 },
            { 0, 0, 0, 0 }
        };
        private readonly Automaton _automaton = new Automaton(grid);
        private string _testText;

        public string TestText
        {
            get
            {
                return _testText;
            }
            set
            {
                _testText = value;
                RaisePropertyChangedEvent("TestText");
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
            TestText = _automaton.Universe.GetCellsAsString();
        }
    }
}
