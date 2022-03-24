using System.IO;
using System.Threading.Tasks;
using Data.Products;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class GeneratorTests
    {
        [TestCase("products.json", 200)]
        public async Task GenerateProducts(string output, int count)
        {
            await using var outputFile = File.Open(output, FileMode.OpenOrCreate);

            var generator = new ProductGenerator();

            Assert.DoesNotThrowAsync(async () => { await generator.Generate(count, outputFile); });
        }
    }
}