using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Irony.Parsing;
using System.Collections;
using OLC1_practica1.Juego;

namespace OLC1_practica1.Compilador
{
    //hereda de la clase Accion
    class AccionesGramatica : Accion
    {
        public Object do_action(ParseTreeNode pt_node)
        {
            return action(pt_node);
        }

        public Object action(ParseTreeNode node)
        {
            Object result = null;

            //Un case por cada no terminal y terminal que tengamos en la gramatica.
            switch (node.Term.Name.ToString())
            {
                case "s0":
                    {
                        if (node.ChildNodes.Count == 1)
                        {
                            result = action(node.ChildNodes[0]);
                        }
                        break;
                    }
                case "ini":
                    {
                        
                            result = action(node.ChildNodes[1]);
                        break;
                    }
                case "e":
                    {
                        /*en este caso como la produccion de e (e.Rule) tiene 3 reglas  e = e+t, e= e-t, e = t
                         * la distincion se hace por medio de los hijos que tiene el nodo, en este caso cuando
                         * tiene un hijo Childnodes.Count = 1 y cuando tiene 3 que seria la suma o la resta*/
                        
                        //si tiene un hijo e = t entonces se llama recursivamente al parser con el result.
                        if (node.ChildNodes.Count == 1)
                        {
                            result = action(node.ChildNodes[0]);
                        }
                        //si tiene 3 hijos quiere decir que es una suma o una resta por lo que se reduce la operacion
                        //y se opera el result.

                        else if (node.ChildNodes.Count == 3)
                        {
                            //se convierten a decimal los valores 
                            double op1 = Convert.ToDouble(action(node.ChildNodes[0]).ToString());
                            double op2 = Convert.ToDouble(action(node.ChildNodes[2]).ToString());
                            
                            //los hijos van de 0 a 2 en este caso ya que son 3 (Childnodes.Count==3) por lo que el hijo[1] corresponde
                            //al operador, por lo que se evalua si es signo mas o signo menos y se opera.
                            if (node.ChildNodes[1].Token.Value.ToString() == "+")
                            {
                                result = op1 + op2;
                            }
                            else
                            {
                                result = op1 - op2;
                            }
                        }
                        break;
                    }
                case "t":
                    {
                        if (node.ChildNodes.Count == 1)
                        {
                            result = action(node.ChildNodes[0]);
                        }
                        else if (node.ChildNodes.Count == 3)
                        {
                            double op1 = Convert.ToDouble(action(node.ChildNodes[0]).ToString());
                            double op2 = Convert.ToDouble(action(node.ChildNodes[2]).ToString());
                            if (node.ChildNodes[1].Token.Value.ToString() == "*")
                            {
                                result = op1 * op2;
                            }
                            else
                            {
                                result = op1 / op2;
                            }
                        }
                        break;
                    }
                case "f":
                    {
                        if (node.ChildNodes.Count == 1)
                        {
                            result = action(node.ChildNodes[0]);
                        }

                        else if (node.ChildNodes.Count == 3)
                        {
                            result = action(node.ChildNodes[1]);
                        }

                        break;
                    }

/*
 * T E R M I N A L E S
 */

                case "componentes":
                    {
                        if (node.ChildNodes.Count == 1)
                        {
                            result = new frm_menujuego();
                            Console.Out.WriteLine(result.GetType().ToString());
                        }
                        //si hay dos no terminales que pueden ser:
                        /* esc componentes
                         * nav componentes
                         * def componentes
                         * ene componentes
                         */
                        else if (node.ChildNodes.Count == 2)
                        {
                            var cmpts = (frm_menujuego)(action(node.ChildNodes[1]));
                            var cmp = action(node.ChildNodes[0]);

                            Console.Out.WriteLine(cmp.GetType().ToString());
                            
                            if (cmp.GetType().ToString() == "OLC1_practica1.Juego.Escenario")
                               {
                                   cmpts.escenarios.Add((Escenario)cmp);
                                   result = cmpts;
                               }
                            else if (cmp.GetType().ToString() == "OLC1_practica1.Juego.Nave")
                               {
                                   cmpts.naves.Add((Nave)cmp);
                                   result = cmpts;
                               }
                            else if (cmp.GetType().ToString() == "OLC1_practica1.Juego.defensa")
                               {
                                   cmpts.defensas.Add((defensa)cmp);
                                   result = cmpts;
                               }
                            else if (cmp.GetType().ToString() == "OLC1_practica1.Juego.enemigo")
                               {
                                   cmpts.enemigos.Add((enemigo)cmp);
                                   result = cmpts;
                               }
                        }
                        break;
                    }
                case "esc":
                    {
                        //por ser un terminal se retorna su valor como tal.
                        var nuevoesc = new Escenario();
                        result = nuevoesc;
                        break;
                    }
                case "nav":
                    {
                        var nuevanave = new Nave();
                        result = nuevanave;
                        break;
                    }
                case "def":
                    {
                        //por ser un terminal se retorna su valor como tal.
                        var nuevadef = new defensa();
                        result = nuevadef;
                        break;
                    }
                case "ene":
                    {
                        var nuevoene = new enemigo();
                        result = nuevoene;
                        break;
                    }
               
            }
            return result;
        }
    }
}
