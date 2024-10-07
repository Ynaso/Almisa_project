using System;
using Almisa_project.Entidades;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace Almisa_project.Datos
{
    public class D_ProductosDelPedido
    {
        public DataTable Listado_ProductosDelPedido(string cTexto)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand comando = new SqlCommand("USP_LISTADO_PRODUCTOS_DEL_PEDIDO", SqlCon);
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

        public string Guardar_ProductoDelPedido(int nOpcion, E_ProductosDelPedido oProductoDelPedido)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand comando = new SqlCommand("USP_GUARDAR_PRODUCTO_DEL_PEDIDO", SqlCon);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@opcion", SqlDbType.Int).Value = nOpcion;
                comando.Parameters.Add("@idPedidosProducto", SqlDbType.Int).Value = oProductoDelPedido.idPedidosProducto;
                comando.Parameters.Add("@idPedido", SqlDbType.Int).Value = oProductoDelPedido.idPedido;
                comando.Parameters.Add("@idProducto", SqlDbType.Int).Value = oProductoDelPedido.idProducto;
                comando.Parameters.Add("@cantidadUnidadesRequeridas", SqlDbType.Int).Value = oProductoDelPedido.cantidadUnidadesRequeridas;
                comando.Parameters.Add("@cantidadUnidadesDespachadas", SqlDbType.Int).Value = oProductoDelPedido.cantidadUnidadesDespachadas ?? (object)DBNull.Value; // Manejo de null
                comando.Parameters.Add("@precioUnitarioAplicado", SqlDbType.Decimal).Value = oProductoDelPedido.precioUnitarioAplicado;
                comando.Parameters.Add("@porcentajeDeDescuentoAplicado", SqlDbType.Decimal).Value = oProductoDelPedido.porcentajeDeDescuentoAplicado ?? (object)DBNull.Value; // Manejo de null

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
