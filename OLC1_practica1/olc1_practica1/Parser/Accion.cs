using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Irony.Parsing;

namespace OLC1_practica1.Compilador
{
    //clase utilizada para asociar acciones a una gramatica. simplemente se puede copiar
    // y pegar ya que solo se llama en la clase asociada a las acciones de nuestra gramatica.
   public interface Accion
    {
        Object do_action(ParseTreeNode pt_node);
        Object action   (ParseTreeNode pt_node);
    }

}
