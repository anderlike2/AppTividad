using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Web;
using System.Text;
using WcfApptividad.Models;
using WcfApptividad.Services;

namespace WcfApptividad
{
    /// <summary>
    /// Ini Server
    /// </summary>
    /// <returns>ResponseModel</returns>
    public class PokemonWcf : IPokemonWcf
    {
        /// <summary>
        /// Create Pokemon data
        /// </summary>
        /// <param name="pokemonData">pokemonData param</param>
        /// <returns>ResponseModel</returns>
        public ResponseModel CreatePokemonData(string pokemonData)
        {
            PokemonService pokemonService = new PokemonService();           
            return pokemonService.CreatePokemonData(pokemonData);
        }

        /// <summary>
        /// Get Pokemon data
        /// </summary>
        /// <param name="id">id param</param>
        /// <returns>ResponseModel</returns>
        public ResponseModel GetPokemonData(int id)
        {
            PokemonService pokemonService = new PokemonService();
            return pokemonService.GetPokemonData(id);
        }
    }
}
