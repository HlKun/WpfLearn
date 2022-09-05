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
using MxDrawXLib;

namespace MxCAD
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly AxMxDrawXLib.AxMxDrawX axMxDrawX = new AxMxDrawXLib.AxMxDrawX();

        public MainWindow()
        {
            InitializeComponent();

            ((System.ComponentModel.ISupportInitialize)axMxDrawX).BeginInit();
            System.Windows.Forms.Integration.WindowsFormsHost host = new System.Windows.Forms.Integration.WindowsFormsHost() { Child = axMxDrawX };
            ((System.ComponentModel.ISupportInitialize)axMxDrawX).EndInit();

            host.SetValue(Grid.ColumnProperty, 0);
            mxdraw.Children.Add(host);

            axMxDrawX.ImplementCommandEvent += new AxMxDrawXLib._DMxDrawXEvents_ImplementCommandEventEventHandler(AxMxDrawX_ImplementCommandEvent);
        }

        private void DrawPoint()
        {
            MxDrawUtility mxUtility = new MxDrawUtility();

            while (true)
            {
                MxDrawPoint point = mxUtility.GetPoint(null, "指定点");
                if (point == null)
                    return;

                axMxDrawX.DrawPoint(point.x, point.y);
            }
        }

        private void DrawPolyLine()
        {
            MxDrawUtility mxUtility = new MxDrawUtility();

            MxDrawPoint point1 = mxUtility.GetPoint(null, "点取第一点");
            if (point1 == null)
                return;

            axMxDrawX.PathMoveTo(point1.x, point1.y);

            MxDrawPoint point2 = mxUtility.GetPoint(point1, "点取下一点");
            if (point2 == null)
                return;

            axMxDrawX.PathLineTo(point2.x, point2.y);
            long id = axMxDrawX.DrawLine(point1.x, point1.y, point2.x, point2.y);

            List<long> tmpobj = new List<long>
            {
                id
            };

            point1 = point2;
            while (true)
            {
                point2 = mxUtility.GetPoint(point1, "点取下一点");
                if (point2 == null)
                    break;

                axMxDrawX.PathLineTo(point2.x, point2.y);
                id = axMxDrawX.DrawLine(point1.x, point1.y, point2.x, point2.y);
                tmpobj.Add(id);

                point1 = point2;
            }

            for (int i = 0; i < tmpobj.Count; i++)
            {
                axMxDrawX.Erase(tmpobj[i]);
            }

            axMxDrawX.DrawPathToPolyline();
        }

        private void AxMxDrawX_ImplementCommandEvent(object sender, AxMxDrawXLib._DMxDrawXEvents_ImplementCommandEventEvent e)
        {
            switch (e.iCommandId)
            {
                case 1:
                    {
                        DrawPoint();
                        break;
                    }
                case 2:
                    {
                        DrawPolyLine();
                        break;
                    }
                default:
                    break;
            }
        }

        private void DrawPointButton_Click(object sender, RoutedEventArgs e)
        {
            axMxDrawX.DoCommand(1);
        }

        private void DrawPolyLineButton_Click(object sender, RoutedEventArgs e)
        {
            axMxDrawX.DoCommand(2);
        }

        private void GetResultButton_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
