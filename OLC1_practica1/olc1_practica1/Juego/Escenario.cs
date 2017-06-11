using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace OLC1_practica1.Juego
{
   public class Escenario: System.Windows.Forms.Panel
    {
        public string pathimg { get; set; }
        public string pathsonido { get; set; }
        public SoundPlayer ssound;
       // public string pathimg { get; set; }
      public  Escenario(string pathimagen, string pathsonido) {
          //@"C:\Users\otto\Pictures\starwars1.jpg"
            this.Size = new Size(400, 300);
            this.BackgroundImage = (Bitmap)Image.FromFile(pathimagen);
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            ssound = new SoundPlayer(pathsonido);
            //ssound.PlayLooping();
            this.Size = new Size(726, 409);
            this.Location = new Point(173,12);
        }

      public Escenario() { 
      }
       

    }
}
