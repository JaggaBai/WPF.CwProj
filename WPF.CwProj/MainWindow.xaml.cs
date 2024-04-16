using System;
using System.Collections.Generic;
using System.IO;
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

namespace WpfAppTest2
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            ListaDoMaloania.Items.Add("Line");
            ListaDoMaloania.Items.Add("Path");
            ListaDoMaloania.Items.Add("Polygon");
            ListaDoMaloania.Items.Add("Polyline");
            ListaDoMaloania.Items.Add("Rectangle");
        }

        bool isDown = false;
        

        void PaintCircle(Brush circleColor, Point position)
        {
            Ellipse ellipse = new Ellipse();
            ellipse.Fill = circleColor;
            ellipse.Width = 15;
            ellipse.Height = 15;
            Canvas.SetLeft(ellipse, position.X);
            Canvas.SetTop(ellipse, position.Y);
            CanvasTest.Children.Add(ellipse);
        }
        void PaintPath(Brush circleColor, Point position)
        {
            System.Windows.Shapes.Path myPath = new System.Windows.Shapes.Path();
            myPath.Stroke = System.Windows.Media.Brushes.Black;
            myPath.Fill = System.Windows.Media.Brushes.MediumSlateBlue;
            myPath.StrokeThickness = 4;
            myPath.HorizontalAlignment = HorizontalAlignment.Left;
            myPath.VerticalAlignment = VerticalAlignment.Center;
            EllipseGeometry myEllipseGeometry = new EllipseGeometry();
            myEllipseGeometry.Center = new System.Windows.Point(50, 50);
            myEllipseGeometry.RadiusX = 25;
            myEllipseGeometry.RadiusY = 25;
            myPath.Data = myEllipseGeometry;
            CanvasTest.Children.Add(myPath);
        }
        void PaintRectangle(Brush circleColor, Point position)
        {
            Rectangle rec= new Rectangle();
            rec.Stroke = System.Windows.Media.Brushes.Black;
            rec.Fill = System.Windows.Media.Brushes.SkyBlue;
            rec.HorizontalAlignment = HorizontalAlignment.Left;
            rec.VerticalAlignment = VerticalAlignment.Center;
            rec.Height = 50;
            rec.Width = 50;
            CanvasTest.Children.Add(rec);
        }
        void PaintLine(Brush circleColor, Point position)
        {
            Line line1 = new Line();
            line1.Stroke = System.Windows.Media.Brushes.LightSteelBlue;
            line1.X1 = 1;
            line1.Y1 = 1;

            line1.X2 = 50;        
            line1.Y2 = 50;
            line1.HorizontalAlignment = HorizontalAlignment.Left;
            line1.VerticalAlignment = VerticalAlignment.Center;
            line1.StrokeThickness = 2;
            CanvasTest.Children.Add(line1);
        }

        void PaintPoligon(Brush circleColor, Point position)
        {
            Polygon pol = new Polygon();
            pol.Stroke = System.Windows.Media.Brushes.Black;
            pol.Fill = System.Windows.Media.Brushes.LightSeaGreen;
           pol.StrokeThickness = 2;
            pol.HorizontalAlignment = HorizontalAlignment.Left;
            pol.VerticalAlignment = VerticalAlignment.Center;
            System.Windows.Point Point1 = new System.Windows.Point(1, 50);
            System.Windows.Point Point2 = new System.Windows.Point(10, 80);
            System.Windows.Point Point3 = new System.Windows.Point(50, 50);
            PointCollection myPointCollection = new PointCollection();
            myPointCollection.Add(Point1);
            myPointCollection.Add(Point2);
            myPointCollection.Add(Point3);
            pol.Points = myPointCollection;
            CanvasTest.Children.Add(pol);
        }
        void PaintPolyline(Brush circleColor, Point position)
        {
            Polyline myPolyline = new Polyline();
            myPolyline.Stroke = System.Windows.Media.Brushes.SlateGray;
            myPolyline.StrokeThickness = 2;
            myPolyline.FillRule = FillRule.EvenOdd;
            System.Windows.Point Point4 = new System.Windows.Point(1, 50);
            System.Windows.Point Point5 = new System.Windows.Point(10, 80);
            System.Windows.Point Point6 = new System.Windows.Point(20, 40);
            PointCollection myPointCollection2 = new PointCollection();
            myPointCollection2.Add(Point4);
            myPointCollection2.Add(Point5);
            myPointCollection2.Add(Point6);
            myPolyline.Points = myPointCollection2;
            CanvasTest.Children.Add(myPolyline);
        }
     
        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (ListaDoMaloania.SelectedItem == "Polyline")
            {
                if (isDown)
                {
                    Point mousePosition = e.GetPosition(CanvasTest);
                    PaintPolyline(Brushes.Black, mousePosition);
                }
            }
            if (ListaDoMaloania.SelectedItem == "Line")
            {
                
                    if (isDown)
                    {
                        Point mousePosition = e.GetPosition(CanvasTest);
                        PaintLine(Brushes.Black, mousePosition);
                    }
                
            }
            if (ListaDoMaloania.SelectedItem == "Path")
            {
                if (isDown)
                {
                    Point mousePosition = e.GetPosition(CanvasTest);
                    PaintPath(Brushes.Black, mousePosition);
                }
            }
            if (ListaDoMaloania.SelectedItem == "Polygon")
            {
                if (isDown)
                {
                    Point mousePosition = e.GetPosition(CanvasTest);
                    PaintPoligon(Brushes.Black, mousePosition);
                }
            }
            if (ListaDoMaloania.SelectedItem == "Rectangle")
            {
                if (isDown)
                {
                    Point mousePosition = e.GetPosition(CanvasTest);
                    PaintRectangle(Brushes.Black, mousePosition);
                }
            }
        }

        private void Canvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            isDown = false;
        }

        private void Canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            isDown = true;
        }
    }
}