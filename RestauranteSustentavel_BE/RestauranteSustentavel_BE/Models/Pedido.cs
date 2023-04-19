namespace RestauranteSustentavel_BE.Models
{
    public class Pedido
    {
        public string data { get; set; }
        public string hora { get; set; }
        public string nomeCliente { get; set; }
        public int id { get; set; }
        public int idPrato { get; set; } //required foreign key from 'Prato'

    }
}
