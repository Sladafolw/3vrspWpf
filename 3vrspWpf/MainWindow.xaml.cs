using _3vrsp;
using System;
using System.Collections.Generic;
using System.Drawing;
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
using System.Xml.Serialization;

namespace _3vrspWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ShowAddRectangle(object sender, RoutedEventArgs e)
        {
            Rect1.Visibility = Visibility.Visible;
            Rect2.Visibility = Visibility.Visible;
            Rect3.Visibility = Visibility.Visible;
            Rect4.Visibility = Visibility.Visible;
            Rect5.Visibility = Visibility.Visible;
            ColorR.Visibility = Visibility.Visible;
            xR.Visibility = Visibility.Visible;
            yR.Visibility = Visibility.Visible;
            WidthR.Visibility = Visibility.Visible;
            HeightR.Visibility = Visibility.Visible;
            AddRect.Visibility = Visibility.Visible;

        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Rect1.Visibility = Visibility.Hidden;
            Rect2.Visibility = Visibility.Hidden;
            Rect3.Visibility = Visibility.Hidden;
            Rect4.Visibility = Visibility.Hidden;
            Rect5.Visibility = Visibility.Hidden;
            ColorR.Visibility = Visibility.Hidden;
            xR.Visibility = Visibility.Hidden;
            yR.Visibility = Visibility.Hidden;
            WidthR.Visibility = Visibility.Hidden;
            HeightR.Visibility = Visibility.Hidden;
            ColorT.Visibility = Visibility.Hidden;
            xT.Visibility = Visibility.Hidden;
            yT.Visibility = Visibility.Hidden;
            a.Visibility = Visibility.Hidden;
            b.Visibility = Visibility.Hidden;
            c.Visibility = Visibility.Hidden;
            Triang11.Visibility = Visibility.Hidden;
            Triang2.Visibility = Visibility.Hidden;
            Triang3.Visibility = Visibility.Hidden;
            Triang4.Visibility = Visibility.Hidden;
            Triang5.Visibility = Visibility.Hidden;
            Triang6.Visibility = Visibility.Hidden;
            AddTriang.Visibility = Visibility.Hidden;
            AddRect.Visibility = Visibility.Hidden;
        }

        private void AddTriangle(object sender, RoutedEventArgs e)
        {
            Triang11.Visibility = Visibility.Hidden;
            Triang2.Visibility = Visibility.Hidden;
            Triang3.Visibility = Visibility.Hidden;
            Triang4.Visibility = Visibility.Hidden;
            Triang5.Visibility = Visibility.Hidden;
            Triang6.Visibility = Visibility.Hidden;
            ColorT.Visibility = Visibility.Hidden;
            xT.Visibility = Visibility.Hidden;
            yT.Visibility = Visibility.Hidden;
            a.Visibility = Visibility.Hidden;
            b.Visibility = Visibility.Hidden;
            c.Visibility = Visibility.Hidden;
            AddTriang.Visibility = Visibility.Hidden;
            try
            {
                _3vrsp.Triangle triangle = new();
           
                triangle.color =(ColorT.Text);
               
                triangle.x = int.Parse(xT.Text);
               
                triangle.y = int.Parse(yT.Text);
           
                triangle.a = int.Parse(a.Text);
         
                triangle.b = int.Parse(b.Text);
           
                triangle.c = int.Parse(c.Text);
                if (triangle.x < 0 && triangle.y < 0 || triangle.a < 0 || triangle.b < 0 || triangle.c<0)
                { Console.Text += ("Введите не отриц значения"); }
                triangle.KindDefenetion(triangle);
                triangle.Sum = triangle.a + triangle.b + triangle.c;
                triangle.Sumxy = triangle.x + triangle.y;
                AFigure.FigureList.Add(triangle);
            }
            catch (Exception ex) { Console.Text+=(ex.ToString());  }

        }

        private void AddRectangle(object sender, RoutedEventArgs e)
        {
            Rect1.Visibility = Visibility.Hidden;
            Rect2.Visibility = Visibility.Hidden;
            Rect3.Visibility = Visibility.Hidden;
            Rect4.Visibility = Visibility.Hidden;
            Rect5.Visibility = Visibility.Hidden;
            ColorR.Visibility = Visibility.Hidden;
            xR.Visibility = Visibility.Hidden;
            yR.Visibility = Visibility.Hidden;
            WidthR.Visibility = Visibility.Hidden;
            HeightR.Visibility = Visibility.Hidden;
            AddRect.Visibility = Visibility.Hidden;
            try
            {
                _3vrsp.Rectangle rectangle = new();

                rectangle.color = (ColorR.Text);


                rectangle.x = int.Parse(xR.Text);

                rectangle.y = int.Parse(yR.Text);

                rectangle.a = int.Parse(WidthR.Text);

                rectangle.b = int.Parse(HeightR.Text);
                if (rectangle.x < 0|| rectangle.y<0 || rectangle.a<0 || rectangle.b < 0)
                { Console.Text += ("Введите не отриц значения"); }
                    rectangle.Sum = rectangle.a + rectangle.b;
                rectangle.Sumxy= rectangle.x + rectangle.y;
                _3vrsp.AFigure.FigureList.Add(rectangle);
            }
            catch (Exception ex) { Console.Text += (ex.ToString()); }
        }


        private void Seriliz(object sender, RoutedEventArgs e)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<AFigure>));



            if (AFigure.FigureList.Count == 0) { return; }

            using (FileStream fs = new FileStream(@"C:\Users\dsdsd\source\repos\3vrsp\3vrsp.xml", FileMode.Create))
            {
                xmlSerializer.Serialize(fs, AFigure.FigureList);

                Console.Text+=("\n Object has been serialized");
            }
        }

        private void DesSeriliz(object sender, RoutedEventArgs e)
        {
            try
            {
               
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<AFigure>));
                using (FileStream fs = new FileStream(@"C:\Users\dsdsd\source\repos\3vrsp\3vrsp.xml", FileMode.OpenOrCreate))
                {
                    AFigure.FigureList = (List<AFigure>)xmlSerializer.Deserialize(fs);
                }
                if (AFigure.FigureList != null)
                {
                    foreach (var f in AFigure.FigureList)
                    {
                        if (f is Triangle oThisIsTriangle)
                        {
                            Console.Text += ($"\n треyгольник sum={oThisIsTriangle.Sum}, color={oThisIsTriangle.color}\n");
                        }
                        else if (f is _3vrsp.Rectangle oThisIsRectangle) { Console.Text += ($"\n прямоугольник sum={oThisIsRectangle.Sum}\n color={oThisIsRectangle.color}\n"); }
                        else Console.Text += ("\n Что ты мне подсунул?");
                    }
                }
            }
            catch (Exception ex) { Console.Text += (ex); return; }
            Console.Text+=($"\n Deserialize");
        }

        private void ShowAddTriangle(object sender, RoutedEventArgs e)
        {
            ColorT.Visibility = Visibility.Visible;
            xT.Visibility = Visibility.Visible;
            yT.Visibility = Visibility.Visible;
            a.Visibility = Visibility.Visible;
            b.Visibility = Visibility.Visible;
            c.Visibility = Visibility.Visible;
            Triang11.Visibility = Visibility.Visible;
            Triang2.Visibility = Visibility.Visible;
            Triang3.Visibility = Visibility.Visible;
            Triang4.Visibility = Visibility.Visible;
            Triang5.Visibility = Visibility.Visible;
            Triang6.Visibility = Visibility.Visible; AddTriang.Visibility = Visibility.Visible;
        }

        private void Sort(object sender, RoutedEventArgs e)
        {
            AFigure.Sort();
            AFigure.ShowFigures(Console);
        }

        private void ShowFigure(object sender, RoutedEventArgs e)
        {
            AFigure.ShowFigures(Console);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Console.Clear();
        }
    }
}
