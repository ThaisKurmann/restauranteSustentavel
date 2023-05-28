namespace RestauranteSustentavel_BE.Models
{
    public class Prato
    {
        public int idPedido { get; set; } //fk from 'Pedido' table
        public int id { get; set; }//chave primaria
    }
}
