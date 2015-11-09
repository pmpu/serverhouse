using System.Collections.Generic;

namespace serverhouse_web.Models {
    public class SolrObject {
        [SolrUniqueKey("id")]
        public long id { get; set; }

        [SolrField("*")]
        public IDictionary<string, string> properties { get; set; }
    }
}