using AplcacionLogistica.Data;
using AplcacionLogistica.Models;
using Microsoft.Data.SqlClient;
using Dapper;

namespace AplcacionLogistica.Services
{
    public class ServicioTransporte : IServicioTransporte
    {
        private string CadenaConexion;

        public ServicioTransporte(ConexionBD conex)
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

        public async Task<int> setFlota(flota flotaaux)
        {
            using (SqlConnection sqlConnection = conexion())
            {
                try
                {
                    var id = await sqlConnection.QuerySingleAsync<int>(@"insert into flota(id, numeroflota)
                                                                        values(@id,@numeroflota)
                                                                        select 200", flotaaux);
                    return id;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        public async Task<int> setvehiculo(vehiculo vehiculoaux)
        {
            using (SqlConnection sqlConnection = conexion())
            {
                try
                {
                    var id = await sqlConnection.QuerySingleAsync<int>(@"insert into vehiculo(id, placa)
                                                                        values(@Id,@placa)
                                                                        select 200", vehiculoaux);
                    return id;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public async Task<int> setlogisticaEntrega(LogisticaEntrega logisticaentrega)
        {
            using (SqlConnection sqlConnection = conexion())
            {
                try
                {
                    var id = await sqlConnection.QuerySingleAsync<int>(@"insert into logisticaentrega
                                                                        (cantidadproducto,fecharegistro,fecchaentrega,precioenvio,
	                                                                    numeroguia,cliente_id,puertobodega_id ,flota_id ,vehiculo_id ,producto_id)
                                                                        values(@cantidadproducto, @fecharegistro, @fechaentrega,@precioenvio,@numeroguia,  
                                                                         @cliente_id, @puertobodega_id, @flota_id, @vehiculo_id, @producto_id)
                                                                        select 200", logisticaentrega);
                    return id;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public async Task<IEnumerable<LogisticaEntrega>> getlogisticaEntrega()
        {
            using (SqlConnection sqlConnection = conexion())
            {
                return await sqlConnection.QueryAsync<LogisticaEntrega>(@"select cantidadproducto,fecharegistro,fecchaentrega as fechaentrega, precioenvio,
	                                                                    numeroguia,cliente_id,puertobodega_id ,flota_id ,vehiculo_id ,producto_id " +
                                                      "\r\nfrom logisticaentrega");
            }
        }

    }
}
