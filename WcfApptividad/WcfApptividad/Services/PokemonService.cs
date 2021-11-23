using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WcfApptividad.Common;
using WcfApptividad.Daos;
using WcfApptividad.Models;

namespace WcfApptividad.Services
{
    public class PokemonService
    {
        PokemonDao pokemonDao;

        /// <summary>
        /// Create Pokemon data
        /// </summary>
        /// <param name="pokemonData">pokemonData param</param>
        /// <returns>ResponseModel</returns>
        public ResponseModel CreatePokemonData(String pokemonData)
        {
            pokemonDao = new PokemonDao();
            try
            {
                pokemonDao.CreatePokemonData(pokemonData);
                return new ResponseModel(true, Constants.SuccessCreatePokemonData, string.Empty);
            }
            catch (Exception e)
            {
                return new ResponseModel(false, Constants.ErrorCreatePokemonData, e.Message);
            }
           
        }
    }
}