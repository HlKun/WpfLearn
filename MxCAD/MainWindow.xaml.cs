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

            axMxDrawX.InitComplete += AxMxDrawX_InitComplete;
            axMxDrawX.ImplementCommandEvent += AxMxDrawX_ImplementCommandEvent;
        }

        private void AxMxDrawX_InitComplete(object sender, EventArgs e)
        {
            axMxDrawX.RegistUserCustomCommand("BoolPolygon", 1);
        }

        private void AxMxDrawX_ImplementCommandEvent(object sender, AxMxDrawXLib._DMxDrawXEvents_ImplementCommandEventEvent e)
        {
            if (e.iCommandId == 1)
                SelectEntity();
        }

        private void GetResultButton_Click(object sender, RoutedEventArgs e)
        {
            axMxDrawX.Prompt("BoolPolygon");
            axMxDrawX.DoCommand(1);
        }

        private void SelectEntity()
        {
            MxDrawUiPrEntity getEntity = new MxDrawUiPrEntity
            {
                message = "选择一个多边形"
            };

            if (getEntity.go() != MCAD_McUiPrStatus.mcOk)
                return;

            MxDrawPolyline polygon;
            if (getEntity.Entity().ObjectName == "McDbPolyline")
            {
                polygon = (MxDrawPolyline)getEntity.Entity();

                if (!polygon.IsClosed())
                    return;

                polygon.Highlight(true);
            }
            else
                return;

            MxDrawUiPrPoint getPoint = new MxDrawUiPrPoint
            {
                message = "选择一个点"
            };

            if (getPoint.go() != MCAD_McUiPrStatus.mcOk)
            {
                polygon.Highlight(false);
                return;
            }

            MxDrawPoint point = getPoint.value();

            if (polygon.IsClosed())
            {
                List<Vector2D> points = new List<Vector2D>();

                for (int i = 0; i < polygon.NumVerts; i++)
                {
                    MxDrawPoint mxDrawPoint = polygon.GetPointAt(i);
                    points.Add(new Vector2D(mxDrawPoint.x, mxDrawPoint.y));
                }

                bool result = IsPointInPoly(new Vector2D(point.x, point.y), points);
                ResultBox.Items.Add(result ? "In" : "Out");
            }

            polygon.Highlight(false);
        }

        private bool IsPointInPoly(Vector2D P, List<Vector2D> points)
        {
            bool isInPoly = false;

            Vector2D A = points[0];

            for (int i = 1; i <= points.Count; i++)
            {
                Vector2D B = points[i == points.Count ? 0 : i];

                if ((B.Y <= P.Y && P.Y < A.Y) || (A.Y <= P.Y && P.Y < B.Y))
                {
                    Vector2D BP = new Vector2D(P.X - B.X, P.Y - B.Y);
                    Vector2D BA = new Vector2D(A.X - B.X, A.Y - B.Y);

                    double t = BP.X * BA.Y - BP.Y * BA.X;
                    if (A.Y < B.Y)
                        t = -t;

                    if (t < 0)
                        isInPoly = !isInPoly;
                }

                A = B;
            }

            return isInPoly;
        }
    }

    public class Vector2D
    {
        public Vector2D(double _x, double _y)
        {
            X = _x;
            Y = _y;
        }

        public double X { get; set; }
        public double Y { get; set; }
    }
}
