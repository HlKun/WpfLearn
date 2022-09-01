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

namespace Event_Attached
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //button.AddHandler(School.ReportTimeEvent, new RoutedEventHandler(School_ReportTime));
            School.AddReportTimeHandler(button, new RoutedEventHandler(School_ReportTime));
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            RoutedEventArgs routedEventArgs = new RoutedEventArgs(School.ReportTimeEvent, new School());
            button.RaiseEvent(routedEventArgs);
        }

        private void School_ReportTime(object sender, RoutedEventArgs e)
        {
            
        }
    }

    public class School
    {
        public static readonly RoutedEvent ReportTimeEvent = EventManager.RegisterRoutedEvent
           ("ReportTime", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(School));

        public static void AddReportTimeHandler(DependencyObject d,RoutedEventHandler h)
        {
            if (d is UIElement ui)
            {
                ui.AddHandler(ReportTimeEvent, h);
            }
        }

        public static void RemoveReportTimeHandler(DependencyObject d, RoutedEventHandler h)
        {
            if (d is UIElement ui)
            {
                ui.RemoveHandler(ReportTimeEvent, h);
            }
        }
    }
}
