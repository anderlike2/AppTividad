using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace WcfApptividad.Client
{
	[XmlRoot(ElementName = "stat")]
	public class Stat
	{
		[XmlElement(ElementName = "name")]
		public string Name { get; set; }

		[XmlElement(ElementName = "url")]
		public string Url { get; set; }
	}
}