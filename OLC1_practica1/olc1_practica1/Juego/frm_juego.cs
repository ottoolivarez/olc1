using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OLC1_practica1.Juego
{
    public partial class frm_juego : Form
    {

        public ArrayList enemigos { get; set; }

        public Nave miNave { get; set; }

        public Escenario miEscenaro { get; set; }

        bool leftpress, rightpress = new bool();

        public frm_juego()
        {
            InitializeComponent();
            
        }

        private void frm_juego_Shown(object sender, EventArgs e)
        {
           /* foreach (var item in Controls)
            {
                if (item is Escenario)
                {
                     ((Escenario)item).ssound.PlayLooping();   
                }
                else if (item is Nave) {
                    this.miNave = (Nave)item;
                }
            }*/
            this.miEscenaro.ssound.PlayLooping();
            this.Controls.Add(miNave);
            this.Controls.Add(miEscenaro);
            this.timer1.Start();
        }

        private void frm_juego_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (var item in Controls)
            {
                if (item is Escenario)
                {
                    ((Escenario)item).ssound.Stop();
                }
            }
        }

        private void frm_juego_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void frm_juego_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)//izquierda
            {
                leftpress = true;
            }
            else if (e.KeyCode == Keys.Right)//derecha
            {
                rightpress = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (leftpress)
                if (this.miNave.Bounds.Left> this.miEscenaro.Bounds.Left)
                    this.miNave.Left -= 10;

            if (rightpress)
                if (this.miNave.Bounds.Right  < this.miEscenaro.Bounds.Right)
                    this.miNave.Left += 10;

            //Console.Out.WriteLine( this.miNave.Bounds.Right);
            //Console.Out.WriteLine("Escenario " + (this.miEscenaro.Bounds.Right));
        }

        private void frm_juego_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)//izquierda
            {
                leftpress = false;
            }
            else if (e.KeyCode == Keys.Right)//derecha
            {
                rightpress = false;
            }
        }


    }
}
