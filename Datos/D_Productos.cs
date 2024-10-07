using System;
using Almisa_project.Entidades;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace Almisa_project.Datos
{
    public class D_Productos
    {
        public DataTable Listado_Productos(string cTexto)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand comando = new SqlCommand("USP_LISTAR_PRODUCTOS", SqlCon);
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

        public string Guardar_Producto(int nOpcion, E_Productos oProducto)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand comando = new SqlCommand("USP_GUARDAR_PRODUCTO", SqlCon);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@opcion", SqlDbType.Int).Value = nOpcion;
                comando.Parameters.Add("@idProducto", SqlDbType.Int).Value = oProducto.idProducto;
                comando.Parameters.Add("@CodigoBarras", SqlDbType.VarChar).Value = oProducto.CodigoBarras;
                comando.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = oProducto.Nombre;
                comando.Parameters.Add("@PresentacionComercial", SqlDbType.VarChar).Value = oProducto.PresentacionComercial;
                comando.Parameters.Add("@PrecioUnitarioActual", SqlDbType.Decimal).Value = oProducto.PrecioUnitarioActual;
                comando.Parameters.Add("@PesoEnKilogramos", SqlDbType.Decimal).Value = oProducto.PesoEnKilogramos;
                comando.Parameters.Add("@UnidadesEnBodega", SqlDbType.Int).Value = oProducto.UnidadesEnBodega;
                comando.Parameters.Add("@IdCategoria", SqlDbType.Int).Value = oProducto.IdCategoria;
                comando.Parameters.Add("@idProductor", SqlDbType.Int).Value = oProducto.idProductor;

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

        // Puedes agregar métodos para eliminar, etc.
    }
}
