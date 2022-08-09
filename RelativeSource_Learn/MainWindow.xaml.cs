﻿using System;
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

namespace RelativeSource_Learn
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Student> Students { get; set; }

        public string NewName { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            Students = new List<Student>()
            {
                new Student(){ Name = "H",Age = 25 }
            };

            NewName = "HLK";

            DataContext = this;
        }
    }

    public class Student
    {
        public string Name { get; set; }

        public int Age { get; set; }
    }
}
