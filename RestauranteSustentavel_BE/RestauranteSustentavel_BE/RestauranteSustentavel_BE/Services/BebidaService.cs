using RestauranteSustentavel_BE.Models;
using RestauranteSustentavel_BE.Repository;

namespace RestauranteSustentavel_BE.Services
{
    public class BebidaService
    {

        private readonly BebidaRepository bebidaRepository;


        public BebidaService(BebidaRepository bebidaRepository) { 
            this.bebidaRepository = bebidaRepository;
        }

        //CREATE
        public Bebida Insert(Bebida bebida)
        {
            return bebidaRepository.InsertBebida(bebida);
        }

        //READ
        public IEnumerable<Bebida> GetAll()
        {
            return bebidaRepository.GetAllBebida();
        }

        
        //UPDATE
        public Bebida Update(Bebida bebida)
        {
            return bebidaRepository.UpateBebida(bebida);
        }


        //DELETE
        public int Delete(int i)
        {
            return bebidaRepository.DeleteBebida(i);

        }
    }
}
