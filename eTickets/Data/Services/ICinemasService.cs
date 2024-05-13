using eTickets.Models;

namespace eTickets.Data.Services
{
    public interface ICinemasService
    {
        Task<IEnumerable<Cinema>> GetAllAsync();
        Task<Cinema> GetByIdAsync(int id);
        Task AddAsync(Cinema cinema);
        Task UpdateAsync(int id, Cinema cinema);
        Task DeleteAsync(int id);
    }

}
