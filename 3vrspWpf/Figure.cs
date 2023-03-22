using _3vrspWpf;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace _3vrsp
{
    [Serializable]
    [XmlInclude(typeof(Triangle))]
    [XmlInclude(typeof(Rectangle))]
    [XmlInclude(typeof(Color))]
    public abstract class AFigure : IDisposable, IComparable
    {
       
        public string color
        {
            get;
            set;
        }
        public int x { get; set; }
        public int y { get; set; }
        public int a { get; set; }
        public int b { get; set; }
        public int Sum { get; set; }
        public int Sumxy { get;set; }
        public virtual int CompareTo(object? obj)
        {
            if (obj is Triangle triangle) { return (x + y) - (triangle.x + triangle.y); /*} return Sum.CompareTo(triangle.Sum);*/ }
            if (obj is Rectangle rectangle) { return ((x + y) - (rectangle.x + rectangle.y)); /*} return Sum.CompareTo(triangle.Sum);*/ }
            else throw new ArgumentException("Некорректное значение параметра");
        }
        public static void ShowFigures(TextBox console)
        {
            foreach (var a in FigureList)
            {
                if (a is Rectangle rec)
                {
                    console.Text+=($"\n это прямоугольник сторона \n координаты привязки=({rec.x},{rec.y})\n периметр={rec.Sum}\n  color={rec.color}\n");
                }
                else if(a is Triangle triangle)
                {
                    console.Text+=($"\n это треугольник{triangle.kindTriangle} \n  координаты привязки=({triangle.x},{triangle.y})\n периметр={triangle.Sum}\ncolor={triangle.color}");
                }
            }
            console.Text += "------------------------------------------------------------------------------";

        }
        public static void Sort()
        {

            FigureList= FigureList.OrderBy(x => x.Sum)
                                    .ThenBy(x => x.Sumxy)
                                    .ToList();
               
            
        }
        public virtual void Dispose()
        {
            throw new NotImplementedException();
        }
        public static List<AFigure> FigureList = new();
    }

}
