using MarkdownSharp;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MetadataMarkdownSharp
{
    public class MetadataMarkdown : Markdown
    {
        #region MarkdownSharp Overrides

        public MetadataMarkdown() : base()
        {

        }

        public MetadataMarkdown(bool loadOptionsFromConfigFile) : base(loadOptionsFromConfigFile)
        {

        }

        public MetadataMarkdown(IMarkdownOptions options) : base(options)
        {

        }

        /// <summary>
        /// Overrides the MarkdownSharp.Markdown class's .Transform() method,
        /// but omits the MetadataMarkdown metadata from the text before
        /// sending it to MarkdownSharp for transformation.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public new string Transform(string text)
        {
            var metadataSection = GetMetadataSection(text);

            if (string.IsNullOrWhiteSpace(metadataSection))
            {
                return base.Transform(text);
            }

            var markdownSection = text.Substring(metadataSection.Length);

            return base.Transform(markdownSection);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Parses the metadata section at the head of a markdown document
        /// into a collection if key/value pairs
        /// </summary>
        /// <param name="text">A string containing some Markdown with or without metadata</param>
        /// <returns>A list of key/value pairs of all metadata items at the top of the markdown text</returns>
        public IEnumerable<KeyValuePair<string, string>> Metadata(string text)
        {
            var metadataSection = GetMetadataSection(text);
            var metadata = ParseMetadataSection(metadataSection);
            return metadata;
        }

        #endregion

        #region Private Methods

        private static string GetMetadataSection(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return string.Empty;
            }

            StringBuilder output = new StringBuilder();

            using (var sr = new StringReader(input))
            {
                while (sr.Peek() != -1)
                {
                    var line = sr.ReadLine();

                    if (string.IsNullOrWhiteSpace(line))
                    {
                        // metadata section ends at the first blank line
                        break;
                    }

                    output.AppendLine(line);
                }
            }

            return output.ToString();
        }

        private static IEnumerable<KeyValuePair<string, string>> ParseMetadataSection(string input)
        {
            IList<KeyValuePair<string, string>> keyValuePairs = new List<KeyValuePair<string, string>>();

            if (!string.IsNullOrWhiteSpace(input))
            {
                using (var sr = new StringReader(input))
                {
                    while (sr.Peek() != -1)
                    {
                        var line = sr.ReadLine();

                        if (string.IsNullOrWhiteSpace(line))
                        {
                            // metadata section ends at the first blank line
                            break;
                        }

                        if (!line.Contains(":"))
                        {
                            // metadata lines must contain a colon to separate the key from the value
                            continue;
                        }

                        // we already verified that the line contains a colon
                        // so this should never be negative or out of range
                        var keyValueSeparatorPosition = line.IndexOf(':');
                        var key = line.Substring(0, keyValueSeparatorPosition).Trim();
                        var value = line.Substring(keyValueSeparatorPosition + 1).Trim();
                        keyValuePairs.Add(new KeyValuePair<string, string>(key, value));
                    }
                }
            }

            return keyValuePairs;
        }

        #endregion
    }
}
