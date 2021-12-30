using System.Threading.Tasks;

namespace EvolentHealthTest.Interface
{
    /// <summary>
    /// Repository
    /// </summary>
    public interface IRepository
    {
        void Save();
        Task SaveAsync();
    }
}
