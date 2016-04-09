using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeSharp.Model
{
    public class Automaton
    {
        public int Age { get; private set; }
        public Grid Universe { get; }

        public Automaton(int width, int height)
        {
            Age = 0;
            Universe = new GridConvolution(width, height);
        }

        public Automaton(int[,] cells)
        {
            Age = 0;
            Universe = new GridConvolution(cells);
        }

        public void Evolve()
        {
            Universe.Evolve();
            Age++;
        }
    }
}
