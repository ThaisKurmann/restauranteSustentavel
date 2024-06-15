using RestauranteSustentavel_BE.Models;
using RestauranteSustentavel_BE.Repository;

namespace RestauranteSustentavel_BE.Services
{
    public class IngredienteService
    {
        private readonly IngredienteRepository ingredienteRepository;




        public IngredienteService(IngredienteRepository ingredienteRepository)
        {
            this.ingredienteRepository = ingredienteRepository;
        }

        //CREATE
        public Ingrediente Insert(Ingrediente ingrediente)
        {
            return ingredienteRepository.InsertIngrediente(ingrediente);
        }

        //READ
        public List<Ingrediente> GetAll()
        {
            return ingredienteRepository.GetAllIngrediente();
        }

        
        //UPDATE
        public Ingrediente Update(Ingrediente ingrediente)
        {
            return ingredienteRepository.UpateBebida(ingrediente);
        }

        //DELETE
        public int Delete(int i)
        {
            return ingredienteRepository.DeleteIngrediente(i);

        }

        //Busca um ingrediente por ID
        public Ingrediente BuscaIngredientePorId(int idIngrediente)
        {
            return ingredienteRepository.BuscaIngredientePorId(idIngrediente);
        }

    }
}
