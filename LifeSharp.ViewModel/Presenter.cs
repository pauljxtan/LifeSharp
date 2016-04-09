using LifeSharp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LifeSharp.ViewModel
{
    class Presenter : ObservableObject
    {
        private Automaton _automaton;

        public Grid Universe
        {
            get
            {
                return _automaton.Universe;
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
        }
    }
}
