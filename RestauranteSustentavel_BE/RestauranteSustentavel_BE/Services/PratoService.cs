using RestauranteSustentavel_BE.Repository;
using RestauranteSustentavel_BE.Models;
using System.Security.Permissions;

namespace RestauranteSustentavel_BE.Services
{
    public class PratoService
    {

        private readonly IngredientePratoRepository ingredientePratoRepository;



        public PratoService(IngredientePratoRepository ingredientePratoRepository)
        {
            this.ingredientePratoRepository = ingredientePratoRepository;
        }

        //TODO: CREATE implementar maneira correta
        public void Insert(IngredientePrato ingredientePrato)
        {
            //IngredientePrato ingredientePratoBD = ingredientePratoRepository.BuscaIngredientesEmPrato(ingredientePrato.idIngrediente);
        }

        //READ
        public List<IngredientePrato> GetAllIngredientePrato()
        {
            return ingredientePratoRepository.GetAllIngredientePrato();
        }

        //UPDATE
        public IngredientePrato UpdateIngredientePrato(IngredientePrato ingredientePrato)
        {
            return ingredientePratoRepository.UpadateIngredientePrato(ingredientePrato);
        }

        //DELETE
        public void DeleteIngredientePrato(IngredientePrato ingredientePrato)
        {
            ingredientePratoRepository.DeleteIngredientePrato(ingredientePrato);
        }

        //BUSCA: Retorna prato da tabela IngredientePrato
        public List<IngredientePrato> BuscaPratoEmIngredientePrato(int idPrato)
        {
            return ingredientePratoRepository.BuscaPratoEmIngredientePratoBD(idPrato);
        }




    }
}
