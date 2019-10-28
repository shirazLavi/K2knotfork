﻿namespace K2Bridge.Models.Request.Queries
{
    using K2Bridge.Models.Request;
    using K2Bridge.Visitors;
    using Newtonsoft.Json;

    [JsonConverter(typeof(RangeQueryConverter))]
    internal class RangeQuery : LeafQueryClause, IVisitable
    {
        public string FieldName { get; set; }

        public long? GTEValue { get; set; }

        public long? GTValue { get; set; } // isn't created by kibana but kept here for completeness

        public long? LTEValue { get; set; }

        public long? LTValue { get; set; }

        public string Format { get; set; }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}