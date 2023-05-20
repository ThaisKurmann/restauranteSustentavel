namespace RestauranteSustentavel_BE.Models
{
    public class PedidoSobremesa
    {
        public int quantidade { get; set; }
        public int idSobremesa { get; set; }//fk de sobremesa
        public int idPedido { get; set; }//fk de pedido

    }
}
