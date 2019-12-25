using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace WpfEmail
{
    class MyModel: INotifyPropertyChanged
    {
        

        public void OpenFile(string aFileName, Encoding aEncoding)
        {
            Text = File.ReadAllText(aFileName, aEncoding);
            FileText = Text;
        }

        public void OpenImage()
        {
            OpenFileDialog aDlg = new OpenFileDialog()
            {
                Title = "选择图片",
                Filter = "jpg|*.jpg|jpeg|*.jpeg",
            };
            if (aDlg.ShowDialog() != true) return;
            ImageName = aDlg.FileName;
        }

        public bool isTrueEmailAdress()
        {
            
            Regex regex = new Regex("^\\s*([A-Za-z0-9_-]+(\\.\\w+)*@(\\w+\\.)+\\w{2,5})\\s*$");
            if (!string.IsNullOrEmpty(EmailAdress))
            {
                if (regex.IsMatch(EmailAdress))
                {
                    
                    return true;
                }
                else
                {
                    //MessageBox.Show("邮箱格式错误！");
                    return false;
                }
            }
            else
            {
                return false;
            }
            

        }
        

        private string _Text;
        public string Text
        {
            get => _Text;
            set
            {
                if (_Text == value) return;
                _Text = value;
                OnPropertyChanged(nameof(Text));
            }
        }

        private string _FileText;
        public string FileText
        {
            get => _FileText;
            set
            {
                if (_FileText == value) return;
                _FileText = value;
                OnPropertyChanged(nameof(FileText));
            }
        }


        private string _ImageName;
        public string ImageName
        {
            get => _ImageName;
            set
            {
                if (_ImageName == value) return;
                _ImageName = value;
                OnPropertyChanged(nameof(ImageName));
            }
        }

        private string _EmailAdress;
        public string EmailAdress
        {
            get => _EmailAdress;
            set
            {
                if (_EmailAdress == value) return;
                _EmailAdress = value;
                isTrueEmailAdress();
                OnPropertyChanged(nameof(EmailAdress));
            }
        }


        private void OnPropertyChanged(string aPropertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(aPropertyName));
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
