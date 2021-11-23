using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfApptividad.Daos
{
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
    }
}