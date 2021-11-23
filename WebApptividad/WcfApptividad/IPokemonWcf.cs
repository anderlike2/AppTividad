using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WcfApptividad.Models;

namespace WcfApptividad
{
    /// <summary>
    /// Ini Server Interface
    /// </summary>
    /// <returns>ResponseModel</returns>
    [ServiceContract]
    public interface IPokemonWcf
    {
        /// <summary>
        /// Create Pokemon data
        /// </summary>
        /// <param name="pokemonData">pokemonData param</param>
        /// <returns>ResponseModel</returns>
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json)]
        ResponseModel CreatePokemonData(string pokemonData);

        /// <summary>
        /// Get Pokemon data
        /// </summary>
        /// <param name="id">id param</param>
        /// <returns>ResponseModel</returns>
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json)]
        ResponseModel GetPokemonData(int id);
    }
}
