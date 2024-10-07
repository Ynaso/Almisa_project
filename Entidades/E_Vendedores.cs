using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almisa_project.Entidades
{
    public class E_Vendedores
    {
        public int idVendedor { get; set; } // Clave primaria
        public string DocumentoIdentidad { get; set; } // Documento de identidad
        public string TipoDocumento { get; set; } // Tipo de documento (puede ser nulo)
        public string Nombres { get; set; } // Nombres del vendedor
        public string Apellidos { get; set; } // Apellidos del vendedor
        public DateTime? FechaNacimiento { get; set; } // Fecha de nacimiento (puede ser nulo)
        public DateTime? FechaVinculacion { get; set; } // Fecha de vinculación (puede ser nulo)
        public decimal? SalarioBase { get; set; } // Salario base (puede ser nulo)
        public int? EidVendedorJefe { get; set; } // Clave foránea hacia Vendedor Jefe (puede ser nulo)
        public int? CidCiudadBaseDeOperaciones { get; set; } // Clave foránea hacia Ciudad de operaciones (puede ser nulo)
    }
}
