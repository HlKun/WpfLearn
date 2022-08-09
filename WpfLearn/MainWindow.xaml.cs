using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfLearn
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public static int myVar;

        public int MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
        }

        public void GetName ()
        {
            myVar = 1;
        }

        public MainWindow()
        {
            //ResourceDictionary resourceDictionary = new ResourceDictionary
            //{
            //    { "brush", new SolidColorBrush(new Color()) }
            //};
            //resourceDictionary.MergedDictionaries.Add(resourceDictionary);

            System.Windows.Controls.Button button = new System.Windows.Controls.Button();

            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
        }
    }

    public class Dog : DependencyObject
    {
        public int MyProperty
        {
            get { return (int)GetValue(MyPropertyProperty); }
            set { SetValue(MyPropertyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyPropertyProperty =
            DependencyProperty.Register("MyProperty", typeof(int), typeof(Dog new PropertyMetadata(0));


    }
}
