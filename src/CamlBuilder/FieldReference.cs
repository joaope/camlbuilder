namespace CamlBuilder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class FieldReference
    {
        public string Alias { get; set; }

        public bool? Ascending { get; set; }

        public string CreateUrl { get; set; }

        public string DisplayName { get; set; }

        public bool? Explicit { get; set; }

        public string Format { get; set; }

        public string Id { get; set; }

        public string Key { get; set; }

        public string List { get; set; }

        public bool? LookupId { get; set; }

        public string Name { get; set; }

        public string RefType { get; set; }

        public string ShowField { get; set; }

        public bool? TextOnly { get; set; }

        public FieldReferenceFunctionType? Type { get; set; }

        public FieldReference()
        {
        }

        public FieldReference(string name)
        {
            Name = name;
        }

        public static implicit operator FieldReference(string fieldName)
        {
            return new FieldReference(fieldName);
        } 

        internal string GetCaml()
        {
            var values = new List<KeyValuePair<string, string>>();

            if (!string.IsNullOrEmpty(Alias))
            {
                values.Add(new KeyValuePair<string, string>("Alias", Alias));
            }

            if (!string.IsNullOrEmpty(CreateUrl))
            {
                values.Add(new KeyValuePair<string, string>("CreateURL", CreateUrl));
            }

            if (!string.IsNullOrEmpty(DisplayName))
            {
                values.Add(new KeyValuePair<string, string>("DisplayName", DisplayName));
            }

            if (!string.IsNullOrEmpty(Format))
            {
                values.Add(new KeyValuePair<string, string>("Format", Format));
            }

            if (!string.IsNullOrEmpty(Id))
            {
                values.Add(new KeyValuePair<string, string>("ID", Id));
            }

            if (!string.IsNullOrEmpty(Key))
            {
                values.Add(new KeyValuePair<string, string>("Key", Key));
            }

            if (!string.IsNullOrEmpty(List))
            {
                values.Add(new KeyValuePair<string, string>("List", List));
            }

            if (!string.IsNullOrEmpty(Name))
            {
                values.Add(new KeyValuePair<string, string>("Name", Name));
            }

            if (!string.IsNullOrEmpty(RefType))
            {
                values.Add(new KeyValuePair<string, string>("RefType", RefType));
            }

            if (!string.IsNullOrEmpty(ShowField))
            {
                values.Add(new KeyValuePair<string, string>("ShowField", ShowField));
            }

            if (Type.HasValue)
            {
                values.Add(new KeyValuePair<string, string>("Type", GetTypeString(Type.Value)));
            }

            if (Ascending.HasValue)
            {
                values.Add(new KeyValuePair<string, string>("Ascending", Ascending.Value.ToString().ToUpperInvariant()));
            }

            if (Explicit.HasValue)
            {
                values.Add(new KeyValuePair<string, string>("Explicit", Explicit.ToString().ToUpperInvariant()));
            }

            if (LookupId.HasValue)
            {
                values.Add(new KeyValuePair<string, string>("LookupId", LookupId.Value.ToString().ToUpperInvariant()));
            }

            if (TextOnly.HasValue)
            {
                values.Add(new KeyValuePair<string, string>("TextOnly", TextOnly.Value.ToString().ToUpperInvariant()));
            }

            return $"<FieldRef {string.Join("", values.Select(kv => $"{kv.Key}='{kv.Value}'"))}/>";
        }

        private string GetTypeString(FieldReferenceFunctionType type)
        {
            switch (type)
            {
                case FieldReferenceFunctionType.Average:
                    return "AVG";
                case FieldReferenceFunctionType.Count:
                    return "COUNT";
                case FieldReferenceFunctionType.Maximum:
                    return "MAX";
                case FieldReferenceFunctionType.Minimum:
                    return "MIN";
                case FieldReferenceFunctionType.Sum:
                    return "SUM";
                case FieldReferenceFunctionType.StandardDeviation:
                    return "STDEV";
                case FieldReferenceFunctionType.Variance:
                    return "VAR";
                default:
                    throw new ArgumentOutOfRangeException(nameof(Type), type, null);
            }
        }
    }

    public enum FieldReferenceFunctionType
    {
        Average,
        Count,
        Maximum,
        Minimum,
        Sum,
        StandardDeviation,
        Variance
    }
}
