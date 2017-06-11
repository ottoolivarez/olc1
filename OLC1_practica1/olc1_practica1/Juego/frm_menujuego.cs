using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
namespace OLC1_practica1.Juego
{
    public partial class frm_menujuego : Form
    {
         private int pos_nave_arrlist = 0;
        private int pos_esc_arrlist = 0;

       public ArrayList escenarios{get; set;}
       public ArrayList naves { get; set; }
       public ArrayList defensas { get; set; }
       public ArrayList enemigos { get; set; }

        public frm_menujuego()
        {
            InitializeComponent();
            escenarios = new ArrayList();
            naves = new ArrayList();
            defensas = new ArrayList();
            enemigos = new ArrayList();
          //  pictureBox1 = (Nave)naves[0];
         //   pictureBox2 = (Escenario)escenarios[0];
        }

        public new void Show()
        {
            //your code here
            this.pos_nave_arrlist = 0;
            var pb = (Nave)naves[0];
            this.pictureBox1.Image = pb.Image;

            this.pos_esc_arrlist = 0;
            var pb2 = (Escenario)escenarios[0];
            this.pictureBox2.Image = pb2.BackgroundImage;
            //call the shadowed Show method on our form.       
            base.Show();

        }
        private void btnanterior_Click(object sender, EventArgs e)
        {
            if (this.pos_nave_arrlist > 0) {
                pos_nave_arrlist--;
                var pb = (Nave)naves[pos_nave_arrlist];
                this.pictureBox1.Image = pb.Image;
            }
            
            //pictureBox1.Show();
        }

        private void btnsiguiente_Click(object sender, EventArgs e)
        {
            if (this.pos_nave_arrlist < naves.Count-1)
            {
                pos_nave_arrlist++;
                var pb = (Nave)naves[pos_nave_arrlist];
                this.pictureBox1.Image = pb.Image;
                this.Refresh();
            }
        }

        private void btnEscAnterior_Click(object sender, EventArgs e)
        {
            if (this.pos_esc_arrlist > 0)
            {
                pos_esc_arrlist--;
                var pb = (Escenario)escenarios[pos_esc_arrlist];
                this.pictureBox2.Image = pb.BackgroundImage;
            }
        }

        private void btnEscSiguiente_Click(object sender, EventArgs e)
        {
            if (this.pos_esc_arrlist < escenarios.Count - 1)
            {
                pos_esc_arrlist++;
                var pb = (Escenario)escenarios[pos_esc_arrlist];
                this.pictureBox2.Image = pb.BackgroundImage;
                this.Refresh();
            }
        }

        private void btnselecionar_Click(object sender, EventArgs e)
        {
            btnanterior.Enabled = false;
            btnsiguiente.Enabled=false;
        }

        private void btnEscSeleccionar_Click(object sender, EventArgs e)
        {
            btnEscAnterior.Enabled = false;
            btnEscSiguiente.Enabled = false;
        }

        private void btnJugar_Click(object sender, EventArgs e)
        {
            frm_juego mijuego = new frm_juego();
            mijuego.enemigos = this.enemigos;

            var miescenario = (Escenario)this.escenarios[this.pos_esc_arrlist];
            var minave = (Nave)this.naves[this.pos_nave_arrlist];
            minave.Location = new Point( miescenario.Left+ miescenario.Bounds.Width / 2
                , miescenario.Bounds.Bottom-minave.Bounds.Height);
            mijuego.miEscenaro=miescenario;
            mijuego.miNave=minave;
            mijuego.Show();

        }

        
    }
}
