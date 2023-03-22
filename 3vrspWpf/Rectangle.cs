using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3vrsp
{
    [Serializable]
    public class Rectangle : AFigure
    { 
        bool disposed = false;

   
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
            {// освобождаем управляемые ресурсы
                base.Dispose();
            }
            // освобождаем неуправляемые объекты
            disposed = true;
        }

        // Деструктор
        ~Rectangle()
        {
            Dispose(false);
        }
    }
}
