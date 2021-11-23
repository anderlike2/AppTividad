using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WcfApptividad.Models;

namespace WcfApptividad.Daos
{
    /// <summary>
    /// Dao lawyer
    /// </summary>
    public class PokemonDao
    {
        /// <summary>
        /// Create Pokemon data
        /// </summary>
        /// <param name="pokemonData">pokemonData param</param>
        public void CreatePokemonData(string pokemonData)
        {
            using (DataPokemonDataContext db = new DataPokemonDataContext())
            {
                db.CREATEPOKEMONDATA(pokemonData);
            }
        }

        /// <summary>
        /// Get Pokemon data
        /// </summary>
        /// <param name="pokemonData">pokemonData param</param>
        public PokemonInfo GetPokemonData(int id)
        {
            using (DataPokemonDataContext db = new DataPokemonDataContext())
            {
                var pokemonData = db.GETPOKEMONDATABYID(id).First();
                return new PokemonInfo
                {
                    xmlData = pokemonData.XMLDATA,
                    registerDate = pokemonData.REGISTERDATE
                };
            }
        }
    }
}