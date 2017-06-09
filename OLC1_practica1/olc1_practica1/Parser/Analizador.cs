using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Irony.Ast;
using Irony.Parsing;
using System.Data;

/*Esta clase practicamente no cambia ya que solamente se llama en la clase principal para
parsear el texto por lo que solamente se copia y se pega sin ningun problema */

namespace OLC1_practica1.Compilador
{
    public class Analizador
    {
        private Grammar gramatica;
        public LanguageData lenguaje { get; set; }
        public ParseTree s_tree { get; set; }
        private Analizador()
        {
            gramatica = null;
        }

        public Analizador(Grammar gramatica)
        {
            this.gramatica = gramatica;
            lenguaje = new LanguageData(gramatica);
        }

        public Object parse(string str, Accion action)
        {


            Parser p = new Parser(lenguaje);
            s_tree = p.Parse(str);
            if (s_tree.Root != null)
            {
                dispTree(s_tree.Root, 0);
                ActionMaker act = new ActionMaker(s_tree.Root);

                return act.getEval(action);

            }
            else
            {
                StringBuilder html = new StringBuilder();
                html.AppendLine("<html>");
                html.Append("<table>");
                html.Append("<tr><th>Columna</th>");
                html.Append("<th>Linea</th>");
                html.Append("<th>Tipo</th>");
                html.Append("<th>Descripcion</th></tr>");
              //  DataRow filaError;
                
                    foreach (var err in s_tree.ParserMessages)
                    {
                       // filaError = errores.NewRow();
                        Console.Out.WriteLine("Columna"+ err.Location.Column + " Linea: "+ err.Location.Line+" Tipo: "+ err.Level+" Descripcion: "+ err.Message);
                        
                        html.Append("<tr><td>"+ err.Location.Column +"</td>");
                        html.Append("<td>"+  err.Location.Line +"</td>");;
                        html.Append("<td>"+  err.Level +"</td>");
                        html.Append("<td>" + err.Message + "</td></tr>");
                        
                    }
                    
                
                p.RecoverFromError();
                return html.ToString();

            }
        }
/*
        public Object parseCustom(ParseTree s_tree, Accion action)
        {

            if (s_tree.Root != null)
            {
                dispTree(s_tree.Root, 0);
                ActionMaker act = new ActionMaker(s_tree.Root);
                return act.getEval(action);
            }
            else
            {
                List<object> salida = new List<object>();
                salida.Add("Error en compilación.");
                DataTable errores = new DataTable();
                errores.Columns.Add("Columna");
                errores.Columns.Add("Linea");
                errores.Columns.Add("Tipo");
                errores.Columns.Add("Descripcion");
                DataRow filaError;
                if (s_tree.ParserMessages[0].ParserState.ReportedExpectedSet != null)
                {
                    foreach (var err in s_tree.ParserMessages)
                    {
                        filaError = errores.NewRow();
                        filaError["Columna"] = err.Location.Column;
                        filaError["Linea"] = err.Location.Line;
                        filaError["Tipo"] = err.Level;
                        filaError["Descripcion"] = err.Message;
                        errores.Rows.Add(filaError);
                    }
                    salida.Add(errores);
                }



                return salida;

            }
        }
        public Object parseWithoutActions(string str)
        {
            Parser p = new Parser(lenguaje);
            s_tree = p.Parse(str);
            if (s_tree.Root != null)
            {

                return s_tree;

            }
            else
            {
                List<object> salida = new List<object>();
                salida.Add("Error en compilación.");
                DataTable errores = new DataTable();
                errores.Columns.Add("Columna");
                errores.Columns.Add("Linea");
                errores.Columns.Add("Tipo");
                errores.Columns.Add("Descripcion");
                DataRow filaError;
                //errores.Rows.Add()
                if (s_tree.ParserMessages[0].ParserState.ReportedExpectedSet != null)
                {
                    foreach (var err in s_tree.ParserMessages)
                    {
                        filaError = errores.NewRow();
                        filaError["Columna"] = err.Location.Column;
                        filaError["Linea"] = err.Location.Line;
                        filaError["Tipo"] = err.Level;
                        filaError["Descripcion"] = err.Message;
                        errores.Rows.Add(filaError);
                    }
                    salida.Add(errores);
                }



                p.RecoverFromError();
                //return msj;
                return salida;

            }
            //return null;
        }
        */
        public void dispTree(ParseTreeNode node, int level)
        {
            for (int i = 0; i < level; i++)
                Console.Write("  ");
            Console.WriteLine(node);
            foreach (ParseTreeNode child in node.ChildNodes)
                dispTree(child, level + 1);
        }
        private String ToDot(ParseTreeNode node)
        {
            StringBuilder b = new StringBuilder();
            b.Append("graph G { node [margin=0 fontcolor=black fontsize=15 width=0.5 shape=circle style=filled] " + Environment.NewLine);
            String cad = "";
            pintar(node, ref cad);
            b.Append(cad);
            b.Append("}");
            return b.ToString();
        }

        private void pintar(ParseTreeNode node, ref string cad)
        {
            throw new NotImplementedException();
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
                return action.do_action(root);
            }
        }
    }
}
