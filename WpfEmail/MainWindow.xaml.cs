using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UIHelp;

namespace WpfEmail
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Model = new MyModel();
            this.DataContext = Model;
        }
        private MyModel Model;

        private void onOpenFile_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            FileOpenDialog fileDlg = new FileOpenDialog();
            if (fileDlg.ShowDialog() != true) return;
            try
            {
                Model.OpenFile(fileDlg.FileName, fileDlg.CurrentEncoding);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void onOpenImage_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                Model.OpenImage();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        //public bool isTrueEmailAdress2()
        //{
        //    string pattern = @"^([\w-\.]+)@(([0−9]1,3\.[0−9]1,3\.[0−9]1,3\.)|(([\w−]+\.)+))([a−zA−Z]2,4|[0−9]1,3)(?)$";
        //    Regex regex = new Regex(pattern);
        //    if (!string.IsNullOrEmpty(Model.EmailAdress))
        //    {
        //        if (regex.IsMatch(Model.EmailAdress))
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }

        //    }
        //    else
        //    {
        //        return false;
        //    }
            

        //}

        private void onOk_canExecuted(object sender, CanExecuteRoutedEventArgs e)
        {
            
           e.CanExecute = !string.IsNullOrEmpty(Model?.ImageName) && !string.IsNullOrEmpty(Model?.FileText)&&Model.isTrueEmailAdress();
            
        }

        private void onOk_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }
    }
}
