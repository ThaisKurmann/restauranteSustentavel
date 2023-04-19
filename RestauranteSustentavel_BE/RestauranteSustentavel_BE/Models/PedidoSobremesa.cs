namespace RestauranteSustentavel_BE.Models
{
    public class PedidoSobremesa
    {
        public int quantidade { get; set; }
        public float preco { get; set; }
        public int idSobremesa { get; set; } //Required foreign key property from 'Sobremesa'
        public int idPedido { get; set; } //Required foreign key property from 'Pedido'



    }
}
