using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using WcfApptividad.Client;
using WcfApptividad.Common;
using WcfApptividad.Daos;
using WcfApptividad.Models;

namespace WcfApptividad.Services
{
    /// <summary>
    /// Service lawyer
    /// </summary>
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
                pokemonData = pokemonData.Replace(@"""", "'");
                pokemonData = "{ 'stats': " + pokemonData + "}";               
                XNode node = JsonConvert.DeserializeXNode(pokemonData, "root");

                pokemonDao.CreatePokemonData(node.ToString());
                return new ResponseModel(true, Constants.SuccessCreatePokemonData, string.Empty);
            }
            catch (Exception e)
            {
                return new ResponseModel(false, Constants.ErrorCreatePokemonData, e.Message);
            }

        }

        /// <summary>
        /// Get Pokemon data
        /// </summary>
        /// <param name="pokemonData">pokemonData param</param>
        public ResponseModel GetPokemonData(int id)
        {
            pokemonDao = new PokemonDao();
            string jsonResult = string.Empty;
            try
            {
                PokemonInfo pokemonInfo = pokemonDao.GetPokemonData(id);

                //Deserialize XML to Entity
                XmlSerializer serializer = new XmlSerializer(typeof(Root));
                 using (StringReader reader = new StringReader(pokemonInfo.xmlData))
                 {
                    var test = (Root)serializer.Deserialize(reader);
                    jsonResult = Newtonsoft.Json.JsonConvert.SerializeObject(test);
                 }
                return new ResponseModel(true, jsonResult, string.Empty);
            }
            catch (Exception e)
            {
                return new ResponseModel(false, Constants.ErrorCreatePokemonData, e.Message);
            }

        }
    }
}