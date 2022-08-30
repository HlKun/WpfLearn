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

namespace WpfDependecy
{
    /// <summary>
    /// CustomButton.xaml 的交互逻辑
    /// </summary>
    public partial class CustomButton : UserControl
    {
        public CustomButton()
        {
            InitializeComponent();
        }

        public string MyContent
        {
            get { return (string)GetValue(MyContentProperty); }
            set { SetValue(MyContentProperty, value); }
        }

        public static readonly DependencyProperty MyContentProperty =
            DependencyProperty.Register("MyContent", typeof(string), typeof(CustomButton), new PropertyMetadata("", MyContentChanged));

        private static void MyContentChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is CustomButton button)
            {
                Button b = (Button)button.FindName("TitleButton");
                b.Content = (string)e.NewValue;
            }
        }
    }
}
