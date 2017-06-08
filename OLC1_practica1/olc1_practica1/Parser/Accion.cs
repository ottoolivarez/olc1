using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Irony.Parsing;

namespace EjemploIrony1
{
    //clase utilizada para asociar acciones a una gramatica. simplemente se puede copiar
    // y pegar ya que solo se llama en la clase asociada a las acciones de nuestra gramatica.
    interface Accion
    {
        Object do_action(ParseTreeNode pt_node);
        Object action   (ParseTreeNode pt_node);
    }

}
