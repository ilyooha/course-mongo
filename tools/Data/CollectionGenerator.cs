using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Data
{
    public abstract class CollectionGenerator : ICollectionGenerator
    {
        private readonly JsonSerializerSettings _settings = new()
        {
            Formatting = Formatting.None,
            NullValueHandling = NullValueHandling.Ignore
        };

        private string Serialize<T>(T entry)
        {
            return JsonConvert.SerializeObject(entry, _settings);
        }

        protected async Task WriteToFile<T>(IEnumerable<T> items, Stream output, CancellationToken ct = default)
            where T : Document
        {
            await using var writer = new StreamWriter(output, leaveOpen: true);

            foreach (var item in items)
            {
                ct.ThrowIfCancellationRequested();

                await writer.WriteLineAsync(Serialize(item));
            }
        }

        public abstract Task Generate(int count, Stream output, CancellationToken ct = default);
    }
}