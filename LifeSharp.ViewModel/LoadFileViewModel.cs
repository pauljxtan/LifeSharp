using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.Windows.Input;
using LifeSharp.Model;
using System.IO;

namespace LifeSharp.ViewModel
{
    public class LoadFileViewModel : ObservableObject
    {
        private OpenFileDialog _fileDialog;
        //private bool? _fileDialogResult;
        private string _filePath;

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

        public ICommand ShowDialogCommand
        {
            get
            {
                return new DelegateCommand(ShowDialog);
            }
        }

        /*
        public bool? FileDialogResult
        {
            get
            {
                return _fileDialogResult;
            }
            set
            {
                _fileDialogResult = value;
                RaisePropertyChangedEvent("FileDialogResult");
            }
        }
        */

        private void ShowDialog()
        {
            if (_fileDialog.ShowDialog() == true)
            {
                FilePath = _fileDialog.FileName;
                int [,] _seed = Utils.GetArrayFromFile(File.OpenText(_filePath), " ");
                // Do more stuff...
            }
        }
    }
}
