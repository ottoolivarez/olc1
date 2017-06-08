using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace OLC1_practica1.Juego
{
    class Nave : System.Windows.Forms.PictureBox
    {
       public Nave() {
            this.Image = (Bitmap)Image.FromFile(@"C:\Users\otto\Pictures\nave1.PNG");

            this.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }
    }
}
