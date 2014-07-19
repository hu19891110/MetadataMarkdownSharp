MetadataMarkdownSharp
==================

A wrapper for [MarkdownSharp](https://code.google.com/p/markdownsharp/) that enables support for [MultiMarkdown](http://fletcherpenney.net/multimarkdown/) style metadata in markdown content.

## Usage

There are only two differences between MetadataMarkdown and vanilla MarkdownSharp.

1. When passing markdown content to the <code>.Transform()</code> method, the metadata values (if any) will be stripped from the top of the content before transforming the HTML.
2. There is a <code>.Metadata()</code> method, which will parse the markdown content, and return a list of key/value pairs from the metadata section.

## Example
<pre><code>
    string content = ...; // Some markdown formatted content with metadata
    string html = new MultiMarkdown().Transform(content);
    IEnumerable&lt;KeyValuePair&lt;string, string&gt;&gt; metdadata = new MultiMarkdown().Metadata(content);
    string author = metadata.Single(x => x.Key == "Author").Value;
</code></pre>