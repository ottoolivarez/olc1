using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OLC1_practica1.Juego
{
    class enemigo : PictureBox
    {
       public int vida;
       public int ataque;
       public int frecuencia;
       public int velocidad;
       public int punteo;
       public PictureBox disparoEnemi;
        public System.Media.SoundPlayer sonidoDisparo;
        public enemigo(string pathImagenEnemigo
            ,string pathImagenDispario
            ,string pathSonidoDisparo
            ,int vida,int ataque,int frecuencia,int velocidad, int punteo) {
                this.Image = (Bitmap)Image.FromFile(pathImagenEnemigo);
                this.disparoEnemi = new PictureBox();
                this.disparoEnemi.Image = (Bitmap)Image.FromFile(pathImagenDispario);
                this.vida = vida;
                this.ataque = ataque;
                this.frecuencia = frecuencia;
                this.velocidad= velocidad;
                this.punteo = punteo;
                this.sonidoDisparo = new System.Media.SoundPlayer(pathSonidoDisparo);
                this.Size = new Size(35, 55);
        }
        public enemigo()
        {
        }


        public void disparo(){}

    }
}
