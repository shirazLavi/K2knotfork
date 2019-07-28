﻿namespace K2Bridge.KustoConnector
{
    using System.Collections.Generic;
    using System.Data;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    public class KustoParser
    {
        public static void ReadHits(IDataReader reader, ElasticResponse response)
        {
            List<Hit> hits = new List<Hit>();

            while (reader.Read())
            {
                var jo = (JObject)reader.GetValue(0);
                var hit = jo.ToObject<Hit>();
                //hit.highlight = new JObject();
                //hit.highlight.Add("extension", JArray.Parse(@"[""@kibana-highlighted-field@gz@/kibana-highlighted-field@""]"));
                hits.Add(hit);
            }

            response.responses[0].hits.total = hits.Count;
            response.responses[0].hits.hits = hits.ToArray();
        }

        public static void ReadAggs(IDataReader reader, ElasticResponse response)
        {
            var buckets = new List<DateHistogramBucket>();

            while (reader.Read())
            {
                var record = (IDataRecord)reader;
                var bucket = DateHistogramBucket.Create(record);
                buckets.Add(bucket);
            }

            response.responses[0].aggregations._2.buckets = buckets.ToArray();
        }
    }
}
