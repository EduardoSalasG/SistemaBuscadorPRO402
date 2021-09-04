using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBuscador.Testing
{
    interface IContrato
    {
        public int id { get; set; }
        public bool SoyUnMetodo(int soyUnParametro)
        {
            return false;
        }
    }
}
