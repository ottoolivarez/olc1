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
using System.Threading;

namespace OLC1_practica1.Juego
{
    public partial class frm_juego : Form
    {

        //esta lista viene del memu de juegos y es la lista que genera el parser
        public ArrayList enemigos { get; set; }
        //disparos que genera la nave
        public ArrayList disparosnave =new ArrayList();

        public Nave miNave { get; set; }

        public Escenario miEscenaro { get; set; }

        bool leftpress, rightpress = new bool();

        System.Media.SoundPlayer splayer;

        //ThreadStart othreadStart;// = new ThreadStart(correrhilosdisparosnave);
        Thread oThread;

        public frm_juego()
        {
            InitializeComponent();
            //this.othreadStart = new ThreadStart(correrhilosdisparosnave);
            
        }

        private void frm_juego_Shown(object sender, EventArgs e)
        {

            this.m_strCurrentSoundFile = miEscenaro.ssound;
            this.Controls.Add(miNave);
            this.Controls.Add(miEscenaro);
            this.timer1.Start();
            this.tmrDisparosNave.Start();
           // this.oThread = new Thread(new ThreadStart(PlayASound));
           // oThread.Start();
   
                
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
            if (disparosnave.Count < 11)
            {
                if (e.KeyChar == (char)Keys.Space)
                {
                    //Console.Out.WriteLine("espacio");
                    Disparo disp = new Disparo(miNave.pathdisparo, new Point((miNave.Bounds.X + miNave.Width / 2), miNave.Bounds.Y - 30));
                    miNave.sonido_disparo.Play();
                    this.Controls.Add(disp);
                    this.disparosnave.Add(disp);
                    disp.BringToFront();


                }
            }
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

        private void tmrDisparosNave_Tick(object sender, EventArgs e)
        {
            foreach (Disparo shot in disparosnave)
            {
                if (shot.Top > this.miEscenaro.Top)
                    shot.Top -= 10;
            }
        }

        private void correrhilosdisparosnave(){

            PlayASound();
                      
            
        }
        delegate void delegado_sonido(System.Media.SoundPlayer sp);
        private void reproducirsonido(System.Media.SoundPlayer sp)
        {

            if (this.InvokeRequired)//preguntamos si es llamando de un subproceso 
            { 
                //se le indica al delelgado que metodod va a ejecutar.
                delegado_sonido odelegado = new delegado_sonido(reproducirsonido);
             //si el delegado invocara a un metodo con parametros debemos indicarle dichos parámetros 
            object[] parametros = new object[] { sp }; 
            //invocamos el método a través del mismo contexto del formulario (this) y enviamos los parámetros 
            this.Invoke(odelegado); //, parametros); <-- esta parte es si necesitaramos pasar parametros generados del subproceso
            }
            else//esta parte se ejecuta en el hilo principal de la UI
            {

                this.PlaySoundInThread(sp, 1);
                
            }

        }


        /*
 * REGION DE REPRODUCCION DE SONIDO
 */
        private System.Media.SoundPlayer m_strCurrentSoundFile;
        public void PlayASound()
        {
            if (m_strCurrentSoundFile== null)
            {
                splayer=  m_strCurrentSoundFile;
                splayer.Play();
            }
            m_strCurrentSoundFile = null;
            m_nCurrentPriority = 3;
            oThread.Abort();
        }

        int m_nCurrentPriority = 3;
        public void PlaySoundInThread(System.Media.SoundPlayer wavefile, int priority)
        {
            if (priority <= m_nCurrentPriority)
            {
                m_nCurrentPriority = priority;
                if (oThread != null)
                    oThread.Abort();

                m_strCurrentSoundFile = wavefile;
                oThread = new Thread(new ThreadStart(PlayASound));
                oThread.Start();

            }

        }
        /*
         * FIN DE REGION DE REPRODUCCION DE SONIDO
         */
    }



}
    

