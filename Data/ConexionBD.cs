namespace AplcacionLogistica.Data
{
    public class ConexionBD
    {
        private string cadenaConexionSQL;
        public string CadenaConexionSql { get => cadenaConexionSQL; }
        public ConexionBD(string ConexionSql)
        {
            cadenaConexionSQL = ConexionSql;
        }
    }
}
