using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _3vrsp
{
    [Serializable]
    public class Triangle : AFigure
    {
        private bool disposed = false;
        public int c { get; set; }
        public string? kindTriangle;
    
        public void KindDefenetion(Triangle triangle)
        {
            if (triangle.a == triangle.b && triangle.a == triangle.c)
            { kindTriangle = " РАВНОСТОРОННИЙ"; return; }
            if (triangle.a == triangle.b || triangle.b == c || triangle.c == triangle.a)
            {
                kindTriangle = " РАВНОБЕДРЕННЫЙ";
                return;
            }
            if (Math.Pow(triangle.a, 2) == Math.Pow(triangle.b, 2) + Math.Pow(triangle.c, 2) || Math.Pow(triangle.b, 2) == Math.Pow(triangle.a, 2) + Math.Pow(triangle.c, 2) || Math.Pow(triangle.c, 2) == Math.Pow(triangle.a, 2) + Math.Pow(triangle.b, 2))
            { kindTriangle = " Прямоугольный"; return; }
            else { kindTriangle = " Обычный нормальный треугольник"; return; }
        }

    
        public override void Dispose()
        {
            // освобождаем неуправляемые ресурсы
            Dispose(true);
            // подавляем финализацию
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposed) return;
            if (disposing)
            {
               base.Dispose();
            }
            // освобождаем неуправляемые объекты
            disposed = true;
        }

       

        // Деструктор
        ~Triangle()
        {
            Dispose(false);
        }
    }
}
