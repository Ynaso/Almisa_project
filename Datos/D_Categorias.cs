using Almisa_project.Datos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almisa_project.Entidades
{

    public class D_Categorias
    {
        public DataTable listar_categorias(string cTexto)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand comando = new SqlCommand("USP_LISTAR_CATEGORIAS", SqlCon);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@cTexto", SqlDbType.VarChar).Value = cTexto;
                SqlCon.Open();

                Resultado = comando.ExecuteReader();
                Tabla.Load(Resultado);
                return Tabla;
            }

            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
        }

        public string guardar_categoria(int nOpcion, E_Categorias oCategorias)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand comando = new SqlCommand("USP_GUARDAR_CATEGORIA", SqlCon);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@opcion", SqlDbType.Int).Value = nOpcion;
                comando.Parameters.Add("@idCategoria", SqlDbType.Int).Value = oCategorias.idCategoria;
                comando.Parameters.Add("@nombre", SqlDbType.VarChar).Value = oCategorias.nombre;
                comando.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = oCategorias.descripcion;
                SqlCon.Open();
                Rpta = comando.ExecuteNonQuery() >= 1 ? "Ok" : "No se pudieron registrar los datos";

            }

            catch (SqlException sqlEx)
            {
                Rpta = $"Error SQL: {sqlEx.Message}"; // Captura el error SQL
            }
            catch (Exception ex)
            {
                Rpta = ex.Message; // Captura cualquier otro error
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }

            return Rpta;

        }
    }
     
}
