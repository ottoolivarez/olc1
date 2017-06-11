using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace OLC1_practica1.Juego
{
    class Disparo:PictureBox
    {
        public bool vivo=new bool();
        public Disparo(String pahtImage,Point posinicial) {
            this.Image = (Bitmap)Image.FromFile(pahtImage);
            this.Size = new Size(10, 30);
            this.Location = posinicial;
            this.vivo = true;
        }
    }
}
