using MetadataMarkdownSharp;
using MarkdownSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace MetadataMarkdownSharpTests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void TransformNull()
        {
            // arrange
            var metadataMarkdown = new MetadataMarkdown();
            var markdown = new Markdown();

            // act
            var metadataMarkdownResult = metadataMarkdown.Transform(TestData.Null);
            var markdownResult = markdown.Transform(TestData.Null);

            // assert
            Assert.AreEqual(markdownResult, metadataMarkdownResult);
        }

        [TestMethod]
        public void TransformEmptyString()
        {
            // arrange
            var markdown = new Markdown();
            var metadataMarkdown = new MetadataMarkdown();

            // act
            var markdownResult = markdown.Transform(TestData.EmptyString);
            var metadataMarkdownResult = markdown.Transform(TestData.EmptyString);

            // assert
            Assert.AreEqual(markdownResult, metadataMarkdownResult);
        }

        [TestMethod]
        public void TransformNotMarkdown()
        {
            // arrange
            var markdown = new Markdown();
            var metadataMarkdown = new MetadataMarkdown();

            // act
            var markdownResult = markdown.Transform(TestData.NotMarkdown);
            var metadataMarkdownResult = markdown.Transform(TestData.NotMarkdown);

            // assert
            Assert.AreEqual(markdownResult, metadataMarkdownResult);
        }

        [TestMethod]
        public void TransformMarkdown()
        {
            // arrange
            var markdown = new Markdown();
            var metadataMarkdown = new MetadataMarkdown();

            // act
            var markdownResult = markdown.Transform(TestData.Markdown);
            var metadataMarkdownResult = markdown.Transform(TestData.Markdown);

            // assert
            Assert.AreEqual(markdownResult, metadataMarkdownResult);
        }

        [TestMethod]
        public void TransformMetadataMarkdown()
        {
            // arrange
            var markdown = new Markdown();
            var metadataMarkdown = new MetadataMarkdown();

            // act
            var markdownResult = markdown.Transform(TestData.MetadataMarkdown);
            var metadataMarkdownResult = metadataMarkdown.Transform(TestData.MetadataMarkdown);

            // assert
            Assert.AreEqual(markdownResult, metadataMarkdownResult);
        }

        [TestMethod]
        public void MetadataNull()
        {
            // arrange
            var metadataMarkdown = new MetadataMarkdown();

            // act
            var metadataMarkdownResult = metadataMarkdown.Metadata(TestData.Null);

            // assert
            Assert.IsTrue(!metadataMarkdownResult.Any());
        }

        [TestMethod]
        public void MetadataEmptyString()
        {
            // arrange
            var metadataMarkdown = new MetadataMarkdown();

            // act
            var metadataMarkdownResult = metadataMarkdown.Metadata(TestData.EmptyString);

            // assert
            Assert.IsTrue(!metadataMarkdownResult.Any());
        }

        [TestMethod]
        public void MetadataNotMarkdown()
        {
            // arrange
            var metadataMarkdown = new MetadataMarkdown();

            // act
            var metadataMarkdownResult = metadataMarkdown.Metadata(TestData.NotMarkdown);

            // assert
            Assert.IsTrue(!metadataMarkdownResult.Any());
        }

        [TestMethod]
        public void MetadataMarkdown()
        {
            // arrange
            var metadataMarkdown = new MetadataMarkdown();

            // act
            var metadataMarkdownResult = metadataMarkdown.Metadata(TestData.Markdown);

            // assert
            Assert.IsTrue(!metadataMarkdownResult.Any());
        }

        [TestMethod]
        public void MetadataMetadataMarkdown()
        {
            // arrange
            var metadataMarkdown = new MetadataMarkdown();

            // act
            var metadataMarkdownResult = metadataMarkdown.Metadata(TestData.MetadataMarkdown);

            // assert
            Assert.IsTrue(metadataMarkdownResult.Any());
        }
    }
}
