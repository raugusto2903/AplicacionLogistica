using AplcacionLogistica.Data;
using AplcacionLogistica.Models;
using Microsoft.Data.SqlClient;
using Dapper;

namespace AplcacionLogistica.Services
{
    public class ServicioPuertoBodega : IServicioPuertoBodega
    {
        private string CadenaConexion;

        public ServicioPuertoBodega(ConexionBD conex)
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

        public async Task<int> setPuertoBodega(PuertoBodega puertobodega)
        {
            using (SqlConnection sqlConnection = conexion())
            {
                try
                {
                    var id = await sqlConnection.QuerySingleAsync<int>(@"insert into puertobodega(id, nombre, direccion, pais, ciudad)
                                                                        values(@id,@nombre,@direccion,@pais,@ciudad)
                                                                        select 200", puertobodega);
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
