using System;
using Almisa_project.Entidades;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace Almisa_project.Datos
{
    public class D_Pedidos
    {
        public DataTable Listado_Pedidos(string cTexto)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand comando = new SqlCommand("USP_LISTADO_PEDIDOS", SqlCon);
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

        public string Guardar_Pedido(int nOpcion, E_Pedidos oPedido)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand comando = new SqlCommand("USP_GUARDAR_PEDIDO", SqlCon);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@opcion", SqlDbType.Int).Value = nOpcion;
                comando.Parameters.Add("@idPedido", SqlDbType.Int).Value = oPedido.idPedido;
                comando.Parameters.Add("@fechaRealizacion", SqlDbType.Date).Value = oPedido.fechaRealizacion;
                comando.Parameters.Add("@fechaEstimadaEntrega", SqlDbType.Date).Value = oPedido.fechaEstimadaEntrega;
                comando.Parameters.Add("@fechaRealEntrega", SqlDbType.Date).Value = oPedido.fechaRealEntrega;
                comando.Parameters.Add("@estadoActual", SqlDbType.VarChar).Value = oPedido.estadoActual;
                comando.Parameters.Add("@direccionDestino", SqlDbType.VarChar).Value = oPedido.direccionDestino;
                comando.Parameters.Add("@personaQueRecibe", SqlDbType.VarChar).Value = oPedido.personaQueRecibe;
                comando.Parameters.Add("@idVendedor", SqlDbType.Int).Value = oPedido.idVendedor ?? (object)DBNull.Value; // Manejo de null
                comando.Parameters.Add("@idCiudadDestino", SqlDbType.Int).Value = oPedido.idCiudadDestino ?? (object)DBNull.Value; // Manejo de null
                comando.Parameters.Add("@idCliente", SqlDbType.Int).Value = oPedido.idCliente ?? (object)DBNull.Value; // Manejo de null

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
