using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Irony.Parsing;

namespace OLC1_practica1
{
    class Gramatica:Grammar
    {
        public Gramatica() { 
        
            /*
             * TERMINALES
             */

           // RegexBasedTerminal id = new RegexBasedTerminal("id", "[a-zA-Z]");
            IdentifierTerminal identifier = new IdentifierTerminal("identifier");

            CommentTerminal comment = new CommentTerminal("multilineComment", "/*", "*/");
            NonGrammarTerminals.Add(comment);
           // var comillas = new RegexBasedTerminal("comillas", "[\"]");
           // var dospuntos = new RegexBasedTerminal("dospuntos", "[:]");
            var coma = new RegexBasedTerminal("coma", "[,]");
           // var puntoyComa = new RegexBasedTerminal("coma", "[;]");
            var igual = new RegexBasedTerminal("igual", "[=]");
            //var numero = TerminalFactory.CreateCSharpNumber("numero");
            var cadena = new StringLiteral("cadena", "\"", StringOptions.None); //Esta joya ya nos hace el business de "algo" XD
            
            var inicio = ToTerm("inicio");
            var escenarios = ToTerm("escenarios");
            var fondo = ToTerm("fondo");
            var sonido=ToTerm("sonido");
            var naves = ToTerm("naves");
            var imagen_nave = ToTerm("imagen_nave");
            var imagen_disparo = ToTerm("imagen_disparo");
            var sonido_disparo = ToTerm("sonido_disparo");
            var ataque = ToTerm("ataque");
            var vida = ToTerm("vida");
            var defensas = ToTerm("defensas");
            var imagen_defensa = ToTerm("imagen_defensa");
            var proteccion = ToTerm("proteccion");
            var velocidad = ToTerm("velocidad");
            var enemigos = ToTerm("enemigos");
            var nombre = ToTerm("nombre");
            var imagen_enemigo = ToTerm("imagen_enemigo");
            var frecuencia = ToTerm("frecuencia");
            var punteo = ToTerm("punteo");
            var fin = ToTerm("fin");


            var corchetea = ToTerm("[");
            var corchetec = ToTerm("]");
            var dolar = ToTerm("$");
            var para = ToTerm("(", "(");
            var parc = ToTerm(")", ")");

             RegexBasedTerminal enteros = new RegexBasedTerminal("enteros", "[0-9]+");


             //no terminales
            NonTerminal s0 = new NonTerminal("s0"),
                        e = new NonTerminal("e"),
                        t = new NonTerminal("t"),
                        f = new NonTerminal("f"),
                        ini= new NonTerminal("ini"),
                        tagini=new NonTerminal(""),
                        componentes= new NonTerminal("componentes"),
                        esc =new NonTerminal("esc"),
                        //nuevoesc=new NonTerminal("nuevoesc"),
                        nav=new NonTerminal("nav"),
                        //nuevanav=new NonTerminal("nuevanav"),
                        def=new NonTerminal("def"),
                        //nuevadef=new NonTerminal("nuevadef"),
                        ene=new NonTerminal("ene"),
                        //nuevoene=new NonTerminal("nuevoene"),
                        nfin=new NonTerminal("nfin")
                        ;



            //simbolo inicial S0 = E;
            s0.Rule = ini;

             /*Se puede observar que las reglas deben ir contatenadas, es decir llevar el simbolo "+"
             * ya que representan cadenas
             */ 
            
            ini.Rule= tagini + componentes;

componentes.Rule=	esc +componentes
		            |nav +componentes
		            |def +componentes
		            |ene +componentes
		            |fin;


tagini.Rule= "["+ inicio +"/"+ identifier +"]";
esc.Rule= "["+ escenarios +"/"+ identifier +"]"+ fondo +"="+ cadena +","+ sonido +"="+ cadena +"$";
nav.Rule="["+naves +"/"+ identifier +"]" + imagen_nave +"="+ cadena +","+ imagen_disparo +"="+ cadena +","+ sonido_disparo +"="+ cadena +","+ vida +"="+ e +","+ ataque +"="+ e +"$";
def.Rule= "["+defensas +"/"+ identifier +"]"+ imagen_defensa +"="+ cadena +","+ proteccion +"="+ e +","+ velocidad +"="+ e +"$";
ene.Rule= "["+enemigos+"/"+ identifier +"]"+ nombre +"="+ cadena +","+ imagen_enemigo +"="+ cadena +","+  imagen_disparo +"="+ cadena +","+ sonido_disparo +"="+ cadena +","+ vida +"="+ e +","+ ataque +"="+ e +","+ frecuencia +"="+ e +","+ velocidad + "="+ e +","+ punteo +"="+ e +"$";

            e.Rule = e + "+" + t
                | e + "-" + t
                | t;
            t.Rule = t + "*" + f
                | t + "/" + f
                | f;

            f.Rule = ToTerm("(") + e + ToTerm (")")
                | enteros;
                

            this.Root = s0;


        }

    }
}
