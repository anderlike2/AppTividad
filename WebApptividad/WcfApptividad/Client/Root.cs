using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace WcfApptividad.Client
{
	[XmlRoot(ElementName = "root")]
	public class Root
	{
		[XmlElement(ElementName = "stats")]
		public List<Stats> Stats { get; set; }
	}
}