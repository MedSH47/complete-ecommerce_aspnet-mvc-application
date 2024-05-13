using eTickets.Data.Enums;
using eTickets.Data.Services;
using eTickets.Models;
using Microsoft.EntityFrameworkCore;

public class CinemasService : ICinemasService
{
    private readonly AppDbContext _context;

    public CinemasService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Cinema>> GetAllAsync()
    {
        return await _context.Cinemas.ToListAsync();
    }

    public async Task<Cinema> GetByIdAsync(int id)
    {
        return await _context.Cinemas.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task AddAsync(Cinema cinema)
    {
        _context.Cinemas.Add(cinema);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(int id, Cinema cinemaToUpdate)
    {
        var cinema = await _context.Cinemas.FirstOrDefaultAsync(c => c.Id == id);
        if (cinema != null)
        {
            cinema.Name = cinemaToUpdate.Name;
            cinema.Logo = cinemaToUpdate.Logo;
            cinema.Description = cinemaToUpdate.Description;
            await _context.SaveChangesAsync();
        }
    }

    public async Task DeleteAsync(int id)
    {
        var cinema = await _context.Cinemas.FirstOrDefaultAsync(c => c.Id == id);
        if (cinema != null)
        {
            _context.Cinemas.Remove(cinema);
            await _context.SaveChangesAsync();
        }
    }
}
