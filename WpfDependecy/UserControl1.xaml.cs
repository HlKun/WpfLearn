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
    /// UserControl1.xaml 的交互逻辑
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            //this.DataContext = this;
            InitializeComponent();
        }

        public Brush CustomColor
        {
            get { return (Brush)GetValue(CustomColorProperty); }
            set { SetValue(CustomColorProperty, value); }
        }

        public static readonly DependencyProperty CustomColorProperty =
            DependencyProperty.Register("CustomColor", typeof(Brush), typeof(UserControl1), new FrameworkPropertyMetadata(Brushes.Red));
    }
}
