namespace CamlBuilder
{
    using System;

    public class ListPropertyValueItem
    {
        public bool? AutoHyperLink { get; set; }

        public bool? AutoHyperLinkNoEncoding { get; set; }

        public bool? AutoNewLine { get; set; }

        public string Default { get; set; }

        public bool? ExpandXml { get; set; }

        public bool? HtmlEncode { get; set; }

        public string Select { get; set; }

        public bool? StripWs { get; set; }

        public bool? UrlEncode { get; set; }

        public bool? UrlEncodeAsUrl { get; set; }

        public ListPropertyValueItem(string select)
        {
            if (string.IsNullOrEmpty(select))
            {
                throw new ArgumentNullException(nameof(select));
            }

            Select = select;
        }
    }
}