using AplcacionLogistica.Data;
using AplcacionLogistica.Models;
using Microsoft.Data.SqlClient;
using Dapper;

namespace AplcacionLogistica.Services
{
    public class ServicioProducto : IServicioProducto
    {

        private string CadenaConexion;

        public ServicioProducto(ConexionBD conex)
        {
            CadenaConexion = conex.CadenaConexionSql;
        }
        private SqlConnection conexion()
        {
            try
            {
                var conexion = new SqlConnection(CadenaConexion);
                conexion.Open();
                return conexion;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<int> setProducto(Producto producto)
        {
            using (SqlConnection sqlConnection = conexion())
            {
                try
                {
                    var id = await sqlConnection.QuerySingleAsync<int>(@"insert into producto(id, nombre, precio)
                                                                        values(@id,@nombre,@precio)
                                                                        select 200", producto);
                    return id;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
