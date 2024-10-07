using Almisa_project.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almisa_project.Datos
{
    internal class D_Clientes
    {

        public DataTable Listado_Clientes(string cTexto)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand comando = new SqlCommand("USP_LISTAR_CLIENTES", SqlCon);
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

        public string Guardar_Cliente(int nOpcion, E_Clientes oCliente)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand comando = new SqlCommand("USP_GUARDAR_CLIENTE", SqlCon);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@opcion", SqlDbType.Int).Value = nOpcion;
                comando.Parameters.Add("@idCliente", SqlDbType.Int).Value = oCliente.idCliente;
                comando.Parameters.Add("@nombre", SqlDbType.VarChar).Value = oCliente.nombre;
                comando.Parameters.Add("@direccion", SqlDbType.VarChar).Value = oCliente.direccion;
                comando.Parameters.Add("@telefono", SqlDbType.VarChar).Value = oCliente.telefono;
                comando.Parameters.Add("@idCiudad", SqlDbType.VarChar).Value = oCliente.idCiudadOficinaPrincipal;

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

        // Puedes agregar métodos adicionales para eliminar, actualizar, etc.
    }



}
