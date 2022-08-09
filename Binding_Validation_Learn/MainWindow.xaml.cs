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

namespace Binding_Validation_Learn
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            txt.AddHandler(Validation.ErrorEvent, new RoutedEventHandler(ValidError));
        }

        private void ValidError(object sender, RoutedEventArgs e)
        {
            if (Validation.GetErrors(txt).Count > 0)
            {
                txt.ToolTip = Validation.GetErrors(txt)[0].ErrorContent.ToString();
            }
        }
    }

    public class RangeRuleValid : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (double.TryParse(value.ToString(), out double d))
            {
                if (d >= 0 && d <= 100)
                {
                    return new ValidationResult(true, null);
                }
            }

            return new ValidationResult(false, "out of range");
        }
    }
}
