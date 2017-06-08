using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Irony.Parsing;
using System.Collections;
using OLC1_practica1.Juego;

namespace EjemploIrony1
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
                            result = action(node.ChildNodes[0]);
                        }
                        //si hay dos no terminales que pueden ser:
                        /* esc componentes
                         * nav componentes
                         * def componentes
                         * ene componentes
                         */
                        else if (node.ChildNodes.Count == 2)
                        {
                            var cmpts = (ArrayList)(action(node.ChildNodes[1]));
                            var cmp = action(node.ChildNodes[0]);
                            if (node.ChildNodes[1].Token.Value.ToString() == "esc")
                            {
                                cmpts.Add((Escenario)cmp);
                                result = cmpts;
                            }
                            else if (node.ChildNodes[1].Token.Value.ToString() == "nav")
                            {
                                cmpts.Add((Escenario)cmp);
                                result = cmpts;
                            }
                            else if (node.ChildNodes[1].Token.Value.ToString() == "def")
                            {
                                cmpts.Add((Escenario)cmp);
                                result = cmpts;
                            }
                            else if (node.ChildNodes[1].Token.Value.ToString() == "ene")
                            {
                                cmpts.Add((Escenario)cmp);
                                result = cmpts;
                            }
                        }
                        break;
                    }
                case "inicio":
                    {
                        //por ser un terminal se retorna su valor como tal.
                        result = node.Token.Value;
                        break;
                    }
                case "escenarios":
                    {
                        //por ser un terminal se retorna su valor como tal.
                        result = node.Token.Value;
                        break;
                    }
                case "fondo":
                    {
                        //por ser un terminal se retorna su valor como tal.
                        result = node.Token.Value;
                        break;
                    }
                case "sonido":
                    {
                        //por ser un terminal se retorna su valor como tal.
                        result = node.Token.Value;
                        break;
                    }
                case "naves":
                    {
                        //por ser un terminal se retorna su valor como tal.
                        result = node.Token.Value;
                        break;
                    }
                case "imagen_nave":
                    {
                        //por ser un terminal se retorna su valor como tal.
                        result = node.Token.Value;
                        break;
                    }
                case "imagen_disparo":
                    {
                        //por ser un terminal se retorna su valor como tal.
                        result = node.Token.Value;
                        break;
                    }
                case "sonido_disparo":
                    {
                        //por ser un terminal se retorna su valor como tal.
                        result = node.Token.Value;
                        break;
                    }
                case "ataque":
                    {
                        //por ser un terminal se retorna su valor como tal.
                        result = node.Token.Value;
                        break;
                    }
                case "vida":
                    {
                        //por ser un terminal se retorna su valor como tal.
                        result = node.Token.Value;
                        break;
                    }
                case "defensas":
                    {
                        //por ser un terminal se retorna su valor como tal.
                        result = node.Token.Value;
                        break;
                    }
                case "imagen_defensa":
                    {
                        //por ser un terminal se retorna su valor como tal.
                        result = node.Token.Value;
                        break;
                    }
                case "proteccion":
                    {
                        //por ser un terminal se retorna su valor como tal.
                        result = node.Token.Value;
                        break;
                    }
                case "velocidad":
                    {
                        //por ser un terminal se retorna su valor como tal.
                        result = node.Token.Value;
                        break;
                    }
                case "enemigos":
                    {
                        //por ser un terminal se retorna su valor como tal.
                        result = node.Token.Value;
                        break;
                    }
                case "nombre":
                    {
                        //por ser un terminal se retorna su valor como tal.
                        result = node.Token.Value;
                        break;
                    }
            }
            return result;
        }
    }
}
