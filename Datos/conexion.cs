using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almisa_project.Datos
{
    public class Conexion
    {

        private string Base;
        private string servidor;
        private string Usuario;
        private string Clave;
        private string tipo;
        private static Conexion Con = null;

      private Conexion()
        {
            this.Base = "ALMISA";
            this.servidor = "WINDOWS-JHAUJ95";
            this.Usuario = "Nisyo";
            this.Clave = "88571387JAa.";
        }

        public SqlConnection CrearConexion()
        {
            SqlConnection Cadena = new SqlConnection();

            Cadena.ConnectionString = "Server=" + this.servidor +
                                    "; Database=" + this.Base +
                                    "; User Id=" + this.Usuario +
                                    "; Password=" + this.Clave;
            try
            {

            }
            catch (Exception ex)
            {
                Cadena = null;
                throw ex;
            }

            return Cadena;
        }


        public static Conexion getInstancia()
        {
            if (Con == null)
            {
                Con = new Conexion();
            }

            return Con;
        }
    }
}
