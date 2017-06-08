﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OLC1_practica1.Compilador;

namespace OLC1_practica1
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Console.Out.WriteLine(e.KeyCode);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Analizador a = new Analizador(new Gramatica());
            //se parsea el texto con el metodo "parse" de la clase Analizador.
            a.parse(textBox1.Text, new AccionesGramatica());
            
            //en este caso se asocia el parseo a un string ya que la salida se muestra en un cuadro de texto pero si
            //solamente se necesita parsear se hace de la forma
            //a.parse(textBox1.Text, new AccionesGramatica());
            
        }
    }
}
