using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfDependecy
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            ContentSource = "BUTTON";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private string contentSource;
        public string ContentSource
        {
            get { return contentSource; }
            set
            {
                contentSource = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ContentSource"));
            }
        }

        private void ShowBtn_Click(object sender, RoutedEventArgs e)
        {
            ContentSource = "B01";
        }
    }
}
