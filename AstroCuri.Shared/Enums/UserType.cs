using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroCuri.Shared.Enums
{
    // sofía
  //atributo que sirve para que el usuario sea tanto seguidor como seguido.
    [Flags]
    public enum UserType
    {
        Ninguno = 0,
        Seguidor = 1,
        Seguido = 2,
        Ambos = Seguidor | Seguido
    }
}
