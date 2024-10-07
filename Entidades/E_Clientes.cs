using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almisa_project.Entidades
{
    public class E_Clientes
    {
        public int idCliente { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public int idCiudadOficinaPrincipal { get; set; } // FK
    }
}
