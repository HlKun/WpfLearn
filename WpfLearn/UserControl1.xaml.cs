using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WpfLearn
{
    /// <summary>
    /// UserControl1.xaml 的交互逻辑
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
            DataContext = this;

            students = new ObservableCollection<Student>()
            {
                new Student{Age = 1, Name = "1"},
                new Student{Age = 2, Name = "2"},
            };
        }

        public ObservableCollection<Student> students { get; set; }
    }

    public class Student
    {
        public int Age { get; set; }
        public string Name { get; set; }
    }
}
