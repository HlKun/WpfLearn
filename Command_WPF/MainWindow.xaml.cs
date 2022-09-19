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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Command_WPF
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = this;

            //button.Command = routedCommand;
            //button.CommandTarget = text;

            //CommandBinding commandBinding = new CommandBinding
            //{
            //    Command = routedCommand
            //};
            //commandBinding.CanExecute += CommandBinding_CanExecute;
            //commandBinding.Executed += CommandBinding_Executed;


            //grid.CommandBindings.Add(commandBinding);

            RelayCommand = new RelayCommand(Relay_Excute, Relay_CanExcute);
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            e.Handled = true;
        }

        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;

            if (string.IsNullOrEmpty(text.Text))
                e.CanExecute = false;

            e.Handled = true;
        }

        private bool Relay_CanExcute(object parameters)
        {
            if (parameters is string s)
            {
                return string.IsNullOrEmpty(s);
            }

            return false;
        }

        private void Relay_Excute(object parameters)
        {
            
        }

        public RoutedCommand routedCommand = new RoutedCommand("test", typeof(Window));

        public RelayCommand RelayCommand { get; set; }
    }
}
