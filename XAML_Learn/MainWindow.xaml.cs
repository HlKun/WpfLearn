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

namespace XAML_Learn
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public Student Student { get; set; }

        public string StudentName { get; set; }

        public List<Student> Students { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            StudentName = "xiaochou";
            Student = new Student { StudentName = "xiaomei", Age = 18 };
            Students = new List<Student>
            {
                new Student { StudentName = "xiaohei", Age = 19 }
            };

            button.SetBinding(ContentProperty, new Binding("Students[0].StudentName"));

            // DataContext、Source区别
            // DataContex 是FrameworkElement的属性、Source 是Binding的属性

        }
    }

    public class Student: INotifyPropertyChanged
    {
        public string StudentName { get; set; }

        public int Age { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
