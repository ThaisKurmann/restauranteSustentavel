namespace RestauranteSustentavel_BE.Models
{
    public class Pedido
    {
        public DateTime data { get; set; }
        public TimeSpan hora { get; set; }
        public string nomeCliente { get; set; }
        public int id { get; set; }
        public int idPrato { get; set; } //required foreign key from 'Prato'
    }
}
