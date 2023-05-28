using RestauranteSustentavel_BE.Models;
using RestauranteSustentavel_BE.Repository;

namespace RestauranteSustentavel_BE.Services
{
    public class SobremesaService
    {
        private readonly SobremesaRepository sobremesaRepository;
       
        
        public SobremesaService(SobremesaRepository sobremesaRepository) 
        {
            this.sobremesaRepository = sobremesaRepository;
        }

        //CREATE
        public Sobremesa Insert(Sobremesa sobremesa)
        {
            return sobremesaRepository.InsertSobremesa(sobremesa);
        }

        //READ
        public List<Sobremesa> Get()
        {
            return sobremesaRepository.GetAllSobremesa();
        }

        //UPDATE
        public Sobremesa Update(Sobremesa sobremesa)
        {
            return sobremesaRepository.UpateSobremesa(sobremesa);
        }


        //DELETE
        public int Delete(int i)
        {
            return sobremesaRepository.DeleteSobremesa(i);

        }

       
    }
}
