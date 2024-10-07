using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almisa_project.Entidades
{
    public class E_Productor
    {
        public int IdProductor { get; set; } // Clave primaria
        public string Nombre { get; set; } // Nombre del productor
        public string DireccionOficinaPrincipal { get; set; } // Dirección de la oficina principal
        public string Telefono { get; set; } // Teléfono del productor
        public int? CidCiudadOficinaPrincipal { get; set; } // Clave foránea hacia Ciudad (nullable)
    }
}
