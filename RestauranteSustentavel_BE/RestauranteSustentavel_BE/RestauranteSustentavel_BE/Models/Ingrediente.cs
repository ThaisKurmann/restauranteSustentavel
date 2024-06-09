using System.Globalization;

namespace RestauranteSustentavel_BE.Models
{
    public class Ingrediente
    {
        public string nome { get; set; }
        public int porcao { get; set; }
        public string tipoAlimento { get; set; }
        public int id { get; set; }
        public float preco { get; set; }

    }
}
