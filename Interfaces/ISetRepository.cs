using System.Threading.Tasks;

namespace SimpleSecureStore
{
    public interface ISetRepository
    {
        Task CreateSetAsync(Set set);
    }
}