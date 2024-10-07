using System;
using Almisa_project.Entidades;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace Almisa_project.Datos
{
    public class D_Vendedores
    {
        public DataTable Listado_Vendedores(string cTexto)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand comando = new SqlCommand("USP_LISTADO_VENDEDORES", SqlCon);
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

        public string Guardar_Vendedor(int nOpcion, E_Vendedores oVendedor)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand comando = new SqlCommand("USP_GUARDAR_VENDEDOR", SqlCon);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@opcion", SqlDbType.Int).Value = nOpcion;
                comando.Parameters.Add("@idVendedor", SqlDbType.Int).Value = oVendedor.idVendedor;
                comando.Parameters.Add("@documentoldentidad", SqlDbType.VarChar).Value = oVendedor.DocumentoIdentidad;
                comando.Parameters.Add("@tipoDocumento", SqlDbType.VarChar).Value = oVendedor.TipoDocumento;
                comando.Parameters.Add("@nombres", SqlDbType.VarChar).Value = oVendedor.Nombres;
                comando.Parameters.Add("@apellidos", SqlDbType.VarChar).Value = oVendedor.Apellidos;
                comando.Parameters.Add("@fechaNacimiento", SqlDbType.Date).Value = oVendedor.FechaNacimiento;
                comando.Parameters.Add("@fechaVinculacion", SqlDbType.Date).Value = oVendedor.FechaVinculacion;
                comando.Parameters.Add("@salarioBase", SqlDbType.Decimal).Value = oVendedor.SalarioBase;
                comando.Parameters.Add("@EidVendedorJefe", SqlDbType.Int).Value = oVendedor.EidVendedorJefe;
                comando.Parameters.Add("@CidCiudadBaseDeOperaciones", SqlDbType.Int).Value = oVendedor.CidCiudadBaseDeOperaciones;

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

        // Puedes agregar métodos para eliminar, actualizar, etc.
    }
}
