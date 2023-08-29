namespace AplcacionLogistica.Models
{
    public class LogisticaEntrega
    {
        public int cantidadproducto { get; set; }
        public string fecharegistro { get; set; }
        public string fechaentrega { get; set; }
        public int precioenvio { get;set; }
        public string numeroguia { get; set; }
        public Int64 cliente_id { get; set; }
        public int puertobodega_id { get; set; }
        public int flota_id { get; set; } = 0;
        public int vehiculo_id { get; set; } = 0;
        public int producto_id { get; set; }
    }
}
