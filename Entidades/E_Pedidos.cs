using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almisa_project.Entidades
{
    public class E_Pedidos
    {
        public int idPedido { get; set; } // (PK, int, not null)
        public DateTime? fechaRealizacion { get; set; } // (date, null)
        public DateTime? fechaEstimadaEntrega { get; set; } // (date, null)
        public DateTime? fechaRealEntrega { get; set; } // (date, null)
        public string estadoActual { get; set; } // (varchar(100), null)
        public string direccionDestino { get; set; } // (varchar(500), null)
        public string personaQueRecibe { get; set; } // (varchar(200), null)
        public int? idVendedor { get; set; } // (FK, int, null)
        public int? idCiudadDestino { get; set; } // (FK, int, null)
        public int? idCliente { get; set; } // (FK, int, null)
    }
}
