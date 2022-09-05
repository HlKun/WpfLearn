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
            axMxDrawX.SetSysVarDouble("PDSIZE", 15.0);

            while (true)
            {
                MxDrawPoint point = mxUtility.GetPoint(null, "指定点:");

                if (point == null)
                    return;

                axMxDrawX.DrawPoint(point.x, point.y);
            }
        }

        private void DrawPolyLine()
        {
            MxDrawPoint point1 = (MxDrawPoint)axMxDrawX.GetPoint(false, 0, 0, "点取第一点:");
            if (point1 == null)
                return;

            //把路径的开始位置移动指定的点
            axMxDrawX.PathMoveTo(point1.x, point1.y);

            //与用户交互到在图上提取一个点
            MxDrawPoint point2 = (MxDrawPoint)axMxDrawX.GetPoint(true, point1.x, point1.y, "点取下一点:");
            if (point2 == null)
                return;

            //把路径下一个点移到指定位置
            axMxDrawX.PathLineTo(point2.x, point2.y);
            long id = axMxDrawX.DrawLine(point1.x, point1.y, point2.x, point2.y);

            List<long> tmpobj = new List<long>
            {
                id
            };

            point1 = point2;
            while (true)
            {
                point2 = (MxDrawPoint)axMxDrawX.GetPoint(true, point1.x, point1.y, "点取下一点:");
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
            if (e.iCommandId == 1)
                DrawPoint();
        }

        private void DrawPolyLineButton_Click(object sender, RoutedEventArgs e)
        {
            axMxDrawX.DoCommand(1);
        }
    }
}
