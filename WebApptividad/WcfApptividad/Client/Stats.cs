using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace WcfApptividad.Client
{
	[XmlRoot(ElementName = "stats")]
	public class Stats
	{
		[XmlElement(ElementName = "base_stat")]
		public int BaseStat { get; set; }

		[XmlElement(ElementName = "effort")]
		public int Effort { get; set; }

		[XmlElement(ElementName = "stat")]
		public Stat Stat { get; set; }
	}
}