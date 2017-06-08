﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Irony.Ast;
using Irony.Parsing;

/*Esta clase practicamente no cambia ya que solamente se llama en la clase principal para
parsear el texto por lo que solamente se copia y se pega sin ningun problema */

namespace EjemploIrony1
{
    class Analizador
    {
        private Grammar gramatica;

        private Analizador()
        {
            gramatica = null;
        }

        public Analizador(Grammar gramatica)
        {
            this.gramatica = gramatica;
        }

        public Object parse(string str, Accion action)
        {
            LanguageData lenguaje = new LanguageData(gramatica);
            Parser p = new Parser(lenguaje);
            ParseTree s_tree = p.Parse(str);
            if (s_tree.Root != null)
            {
                ActionMaker act = new ActionMaker(s_tree.Root);
                return act.getEval(action);
            }
            return null;
        }

        private class ActionMaker
        {
            private ParseTreeNode root;

            public ActionMaker(ParseTreeNode pt_root)
            {
                root = pt_root;
            }

            public Object getEval(Accion action)
            {
                //evaluar el árbol
                return action.do_action(root);
            }
        }
    }
}
