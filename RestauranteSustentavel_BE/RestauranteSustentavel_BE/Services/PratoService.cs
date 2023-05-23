﻿using RestauranteSustentavel_BE.Repository;
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
        public IngredientePrato Insert(IngredientePrato ingredientePrato)
        {
            return ingredientePratoRepository.Insert(ingredientePrato);
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


    }
}