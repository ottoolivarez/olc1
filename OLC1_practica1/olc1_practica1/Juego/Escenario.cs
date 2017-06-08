using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OLC1_practica1.Juego
{
    class Escenario: System.Windows.Forms.Panel
    {
        
        Escenario() {

            this.Size = new Size(400, 300);
            this.BackgroundImage = (Bitmap)Image.FromFile(@"C:\Users\otto\Pictures\starwars1.jpg");
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
           
        }

      
    }
}
