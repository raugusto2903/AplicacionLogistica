using AplcacionLogistica.Data;
using AplcacionLogistica.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace AplcacionLogistica.Services
{
    public class ServicioCliente : IServicioCliente
    {
        private string CadenaConexion;

        public ServicioCliente(ConexionBD conex)
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

        public async Task<int> setCliente(Cliente cliente)
        {
            using (SqlConnection sqlConnection = conexion())
            {
                try
                {
                    var id = await sqlConnection.QuerySingleAsync<int>(@"insert into cliente(id, nombre, telefono, direccion)
                                                                        values(@id,@nombre,@telefono,@direccion)
                                                                        select 200", cliente);
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
