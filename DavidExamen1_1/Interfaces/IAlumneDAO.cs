using System.Collections.Generic;
using System.Threading.Tasks;

namespace DavidExamen1_1.Interfaces
{
    internal interface IDAO<T>
    {
        Task<T> GetAsync(int id);
        Task<List<T>> GetAllAsync();
        Task SaveAsync(T obj);
        Task DeleteAsync(T obj);
    }
}
