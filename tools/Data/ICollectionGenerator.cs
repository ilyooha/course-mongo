using System.IO;
using System.Threading.Tasks;

namespace Data
{
    public interface ICollectionGenerator
    {
        Task Generate(int count, Stream output);
    }
}