using Microsoft.AspNetCore.Cors;
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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    
    public class PokemonWcf : IPokemonWcf
    {
        public ResponseModel CreatePokemonData(string pokemonData)
        {
            string reqXML = pokemonData;
            PokemonService pokemonService = new PokemonService();
            OperationContext context = OperationContext.Current;
            if (context != null && context.RequestContext != null)
            {
                Message msg = context.RequestContext.RequestMessage;
                reqXML = msg.ToString();
            }
            return pokemonService.CreatePokemonData(reqXML);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
