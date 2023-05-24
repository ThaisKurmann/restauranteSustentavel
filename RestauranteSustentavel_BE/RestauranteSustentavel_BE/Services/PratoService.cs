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

        //CREATE 
        public void Insert(IngredientePrato ingredientePrato)
        {
            IngredientePrato ingredientePratoBD = ingredientePratoRepository.BuscaIngredienteEmIngredientePrato(ingredientePrato.idIngrediente, ingredientePrato.idPrato);

            if(ingredientePratoBD!= null)
            {
                //atualiza quantidade de ingrediente nesse prato
                ingredientePratoBD.quantidade += ingredientePrato.quantidade;
                //atualiza BD
                ingredientePratoRepository.UpadateIngredientePrato(ingredientePratoBD);
            }
            else
            {
                ingredientePratoRepository.Insert(ingredientePrato);
            }
        }

        //READ
        public List<IngredientePrato> GetAllIngredientePrato()
        {
            return ingredientePratoRepository.GetAllIngredientePrato();
        }

        //UPDATE
        public void UpdateIngredientePrato(IngredientePrato ingredientePrato, int quantidadeRemover)
        {
            var ingredientePratoBD = ingredientePratoRepository.BuscaIngredienteEmIngredientePrato(ingredientePrato.idIngrediente, ingredientePrato.idPrato);
            

            if(ingredientePratoBD == null)
            {
                return;
            }

            ingredientePratoBD.quantidade -= quantidadeRemover;

            if(ingredientePratoBD.quantidade > 0)
            {
                ingredientePratoRepository.UpadateIngredientePrato(ingredientePratoBD);
            }
            else
            {
                ingredientePratoRepository.DeleteIngredientePrato(ingredientePratoBD);
            }

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

        //BUSCA: Retorna ingrediente x se estah na tabela IngredientePrato
        public IngredientePrato BuscaIngredienteEmIngredientePrato(int idIngrediente, int idPrato)
        {
            return ingredientePratoRepository.BuscaIngredienteEmIngredientePrato(idIngrediente, idPrato);
        }



    }
}
