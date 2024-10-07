using System;
using Almisa_project.Entidades;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace Almisa_project.Datos
{
    public class D_Proveedores
    {
        public DataTable Listado_Proveedores(string cTexto)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand comando = new SqlCommand("USP_LISTADO_PROVEEDORES", SqlCon);
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

        public string Guardar_Proveedor(int nOpcion, E_Proveedores oProveedor)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();

            try
                {
                    SqlCon = Conexion.getInstancia().CrearConexion();
                    SqlCommand comando = new SqlCommand("USP_GUARDAR_PROVEEDOR", SqlCon);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Add("@opcion", SqlDbType.Int).Value = nOpcion;
                    comando.Parameters.Add("@idProveedor", SqlDbType.Int).Value = oProveedor.idProveedor;
                    comando.Parameters.Add("@nombre", SqlDbType.VarChar).Value = oProveedor.nombre;
                    comando.Parameters.Add("@telefono", SqlDbType.VarChar).Value = oProveedor.telefono;

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
