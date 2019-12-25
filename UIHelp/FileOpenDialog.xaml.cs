using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace UIHelp
{
    /// <summary>
    /// FileOpenDialog.xaml 的交互逻辑
    /// </summary>
    public partial class FileOpenDialog : Window
    {
        public FileOpenDialog()
        {
            InitializeComponent();
            _Model = new UIModel();
            this.DataContext = _Model;
        }



        private UIModel _Model;

        public string FileName => _Model.FileName;

        public Encoding CurrentEncoding => _Model.CurrentEncoding;

        private void OnBrowse_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog aDlg = new OpenFileDialog()
            {
                Title = "选择文件",
                Filter = "文本文件 (*.txt)|*.txt|Xml文件 (*.xml)|*.xml|所有文件 (*.*)|*.*",
            };
            if (aDlg.ShowDialog() != true) return;
            _Model.FileName = aDlg.FileName;
        }


        private void OnOk_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void OnOk_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = !string.IsNullOrEmpty(_Model?.FileName);
        }
    }
}
