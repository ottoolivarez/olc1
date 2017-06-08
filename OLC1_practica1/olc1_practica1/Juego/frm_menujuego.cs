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
        ArrayList escenarios;
        ArrayList naves;
        ArrayList defensas;
        ArrayList enemigos;

        public frm_menujuego()
        {
            InitializeComponent();
            escenarios = new ArrayList();
            naves = new ArrayList();
            defensas = new ArrayList();
            enemigos = new ArrayList();

        }

        
    }
}
