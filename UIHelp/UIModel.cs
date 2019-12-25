using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIHelp
{
    class UIModel: INotifyPropertyChanged
    {
        private string _FileName;
        public string FileName
        {
            get => _FileName;
            set { if (_FileName == value) return; _FileName = value; OnPropertyChanged(nameof(FileName)); GetPreview(); }
        }

        private string _Preview;
        public string Preview
        {
            get => _Preview;
            set { if (_Preview == value) return; _Preview = value; OnPropertyChanged(nameof(Preview)); }
        }

        private Encoding _CurrentEncoding = Encoding.Default;
        public Encoding CurrentEncoding
        {
            get => _CurrentEncoding;
            set { if (_CurrentEncoding == value) return; _CurrentEncoding = value; OnPropertyChanged(nameof(CurrentEncoding)); GetPreview(); }
        }
        

        
        private static Encoding[] _Encodings = new Encoding[]
        {
            Encoding.Default, Encoding.UTF7, Encoding.UTF8, Encoding.UTF32, Encoding.ASCII, Encoding.BigEndianUnicode, Encoding.Unicode
        };
        public Encoding[] Encodings => _Encodings;


        private void GetPreview()
        {
            try
            {
                Preview = File.ReadAllText(FileName, CurrentEncoding);
            }
            catch (Exception ex)
            {
                Preview = ex.Message;
            }
        }



        private void OnPropertyChanged(string aPropertyName)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(aPropertyName));
        public event PropertyChangedEventHandler PropertyChanged;
    }

}
