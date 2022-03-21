using System.Threading.Tasks;

namespace Psychologist.UI.Abstractions
{
    public interface IDatabaseFileProvider
    {
        Task CopyToSpecificFolder();
    }
}