using SolrNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace serverhouse_web.Models
{
    public class SolrObject
    {
        [SolrUniqueKey("id")]
        public long id { get; set; }

        [SolrField("*")]
        public IDictionary<string, string> properties { get; set; }
    }
}