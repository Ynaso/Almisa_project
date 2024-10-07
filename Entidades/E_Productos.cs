using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almisa_project.Entidades
{
    public class E_Productos
    {
        public int idProducto { get; set; } // Clave primaria
        public string CodigoBarras { get; set; } // Código de barras
        public string Nombre { get; set; } // Nombre del producto
        public string PresentacionComercial { get; set; } // Presentación del producto
        public decimal PrecioUnitarioActual { get; set; } // Precio unitario actual
        public decimal PesoEnKilogramos { get; set; } // Peso en kilogramos
        public int UnidadesEnBodega { get; set; } // Unidades en bodega
        public int IdCategoria { get; set; } // Clave foránea hacia Categoría
        public int idProductor { get; set; } // Clave foránea hacia Productor
    }
}
