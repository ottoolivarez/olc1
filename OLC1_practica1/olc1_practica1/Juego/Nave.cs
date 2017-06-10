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
       // public string pathimagen { get; set; }
       // public string pathdisparo { get; set; }
       // public string pathsonidodisparo { get; set; }
        public System.Media.SoundPlayer sonido_disparo;
        public int vida { get; set; }
        public int ataque { get; set; }


        public Nave(string pathimagen
            , string pathdisparo
            , string pathsonidodisparo
            , int vida
            , int ataque
            ) {
            //@"C:\Users\otto\Pictures\nave1.PNG"
            this.Image = (Bitmap)Image.FromFile(@pathimagen);
            this.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.sonido_disparo = new System.Media.SoundPlayer(pathsonidodisparo);
        }
        public Nave() { }
    /*    public void construir_nave() { 
        
            if(pathimagen!="" || pathimagen!=null){
            
            }
        }*/

        public void disparo() {
            this.sonido_disparo.Play();
        }
    }
}
