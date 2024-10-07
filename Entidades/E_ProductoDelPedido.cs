using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almisa_project.Entidades
{
    public class E_ProductosDelPedido
    {
        public int idPedidosProducto { get; set; } // (int, not null)
        public int idPedido { get; set; } // (FK, int, not null)
        public int idProducto { get; set; } // (FK, int, not null)
        public int cantidadUnidadesRequeridas { get; set; } // (int, not null)
        public int? cantidadUnidadesDespachadas { get; set; } // (int, null)
        public decimal precioUnitarioAplicado { get; set; } // (decimal(12,2), null)
        public decimal? porcentajeDeDescuentoAplicado { get; set; } // (decimal(18,2), null)
    }
}
