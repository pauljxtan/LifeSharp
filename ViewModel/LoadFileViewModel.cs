using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.Windows.Input;
using System.IO;
using LifeSharp.Model;

namespace LifeSharp.ViewModel
{
    public class LoadFileViewModel : ObservableObject
    {
        private OpenFileDialog _fileDialog;
        private string _filePath;
        private int[,] _seed;
        
        public LoadFileViewModel()
        {
            _fileDialog = new OpenFileDialog();
        }

        public string FilePath
        {
            get
            {
                return _filePath;
            }
            set
            {
                _filePath = value;
                RaisePropertyChangedEvent("FilePath");
            }
        }

        public int[,] Seed
        {
            get
            {
                return _seed;
            }
            set
            {
                _seed = value;
                RaisePropertyChangedEvent("Seed");
                UniverseViewModel.Instance.Automaton = new Automaton(_seed);
            }
        }

        public ICommand ShowDialogCommand
        {
            get
            {
                return new DelegateCommand(ShowDialog);
            }
        }

        private void ShowDialog()
        {
            if (_fileDialog.ShowDialog() == true)
            {
                FilePath = _fileDialog.FileName;
                Seed = Utils.GetArrayFromFile(File.OpenText(_filePath), " ");
            }
        }
    }
}
