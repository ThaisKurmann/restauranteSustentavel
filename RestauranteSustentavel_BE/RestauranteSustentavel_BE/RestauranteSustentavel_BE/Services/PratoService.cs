using RestauranteSustentavel_BE.Repository;
using RestauranteSustentavel_BE.Models;
using System.Security.Permissions;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace RestauranteSustentavel_BE.Services
{
    public class PratoService
    {

        private readonly IngredientePratoRepository ingredientePratoRepository;
        private readonly PratoRepository pratoRepository;
        private readonly IngredienteRepository ingredienteRepository;


        public PratoService(IngredientePratoRepository ingredientePratoRepository, PratoRepository pratoRepository, IngredienteRepository ingredienteRepository)
        {
            this.ingredientePratoRepository = ingredientePratoRepository;
            this.pratoRepository = pratoRepository;
            this.ingredienteRepository = ingredienteRepository;
        }

        //[Prato: CREATE]
        public Prato InsertPrato(int pedidoId)
        {
            //VALIDACAO DO PEDIDO: pedido existe? Se nao=> retorna erro e nao cria um novo prato

            return pratoRepository.Insert(pedidoId);
        }

        //[Prato: READ]
        public List<Prato> GetAllPrato()
        {
            return pratoRepository.GetAll();
        }

        //[Prato: DELETE]
        public void DeletePrato(int id)
        {
            pratoRepository.Delete(id);
        }

        //[Prato: BUSCA -> retorna todos os pratos de um pedido]
        public List<Prato> BuscaPratosPorPedidoId(int idPedido)
        {
            return pratoRepository.BuscaPratosPorPedidoId(idPedido);
        }

        //[IngredientePrato: CREATE]
        public void InsertIngredientePrato(IngredientePrato ingredientePrato)
        {
            IngredientePrato ingredientePratoBD = ingredientePratoRepository.BuscaIngredienteEmIngredientePrato(ingredientePrato.idIngrediente, ingredientePrato.idPrato);

            if (ingredientePratoBD != null)
            {
                //atualiza quantidade de ingrediente nesse prato
                ingredientePratoBD.quantidade += ingredientePrato.quantidade;
                //atualiza BD
                ingredientePratoRepository.Update(ingredientePratoBD);
            }
            else
            {
                ingredientePratoRepository.Insert(ingredientePrato);
            }
        }

        //[IngredientePrato: READ]
        public List<IngredientePrato> GetAllIngredientePrato()
        {
            return ingredientePratoRepository.GetAll();
        }

        //[IngredientePrato:UPDATE]
        public void UpdateQuantidadeIngredienteEmIngredientePrato(IngredientePrato ingredientePrato, int quantidadeRemover)
        {
            var ingredientePratoBD = ingredientePratoRepository.BuscaIngredienteEmIngredientePrato(ingredientePrato.idIngrediente, ingredientePrato.idPrato);


            if (ingredientePratoBD == null)
            {
                return;
            }

            ingredientePratoBD.quantidade -= quantidadeRemover;

            if (ingredientePratoBD.quantidade > 0)
            {
                ingredientePratoRepository.Update(ingredientePratoBD);
            }
            else
            {
                ingredientePratoRepository.Delete(ingredientePratoBD);
            }

        }

        //[IngredientePrato: DELETE]
        public void DeleteIngredientePrato(IngredientePrato ingredientePrato)
        {
            ingredientePratoRepository.Delete(ingredientePrato);
        }

        //[IngredientePrato:BUSCA -> Retorna prato da tabela IngredientePrato]
        public List<IngredientePrato> BuscaPratoEmIngredientePrato(int idPrato)
        {
            return ingredientePratoRepository.BuscaPorPratoId(idPrato);
        }

        //[IngredientePrato: BUSCA -> Retorna ingrediente x se estah na tabela IngredientePrato]
        public IngredientePrato BuscaIngredienteEmIngredientePrato(int idIngrediente, int idPrato)
        {
            return ingredientePratoRepository.BuscaIngredienteEmIngredientePrato(idIngrediente, idPrato);
        }


        //[PratoIngredienteListView: Busca pratos com seu respectivs ingredientes]
        public List<PratoIngredienteListView> ShowIngredientesEmPratoPorPedidoId(int idPedido)
        {
            var pratosView = new List<PratoIngredienteListView>();
            var pedidoPratosList = BuscaPratosPorPedidoId(idPedido);
            var ingrendientePratoList = GetAllIngredientePrato();
            var ingredientes = ingredienteRepository.GetAllIngrediente();

            foreach (var pedidoPrato in pedidoPratosList)
            {
                var ingredientesNoPrato = ingredientePratoRepository.BuscaPorPratoId(pedidoPrato.idPrato);
                var ingredientesString = "";
                foreach(var ingredienteNoPrato in ingredientesNoPrato)
                {
                

                   ingredientesString += ingredientes.Where(ingrediente => ingrediente.id == ingredienteNoPrato.idIngrediente).First().nome + " " + ingredienteNoPrato.quantidade.ToString() + ", ";
                    
                }
                pratosView.Add(new PratoIngredienteListView() { idPrato = pedidoPrato.idPrato, nomeIngredientes = ingredientesString });
            }


            return pratosView;
        }

    }
}

