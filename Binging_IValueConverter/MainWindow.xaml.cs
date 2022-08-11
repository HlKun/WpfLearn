using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace Binging_IValueConverter
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

            Sex = Sex.Female;
        }

        public Sex Sex { get; set; }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }

    public class SexToBoolConverter : IValueConverter
    {
        // Source 2 Target
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Sex sex = (Sex)value;

            if (sex == (Sex)int.Parse(parameter.ToString()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Target 2 Source
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isChecked = (bool)value;
            if (!isChecked)
                return Binding.DoNothing;
            else
                return (Sex)int.Parse(parameter.ToString());
        }
    }

    public enum Sex
    {
        Female,
        Male
    }
}
