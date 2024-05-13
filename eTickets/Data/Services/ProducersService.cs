using eTickets.Data;
using eTickets.Data.Enums;
using eTickets.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eTickets.Data.Services
{
    public class ProducersService : IProducersService
    {
        private readonly AppDbContext _context;

        public ProducersService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Producer>> GetAllAsync()
        {
            return await _context.Producers.ToListAsync();
        }

        public async Task<Producer> GetByIdAsync(int id)
        {
            return await _context.Producers
                                 .Include(p => p.Movies)
                                 .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddAsync(Producer producer)
        {
            _context.Producers.Add(producer);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, Producer producer)
        {
            var existingProducer = await _context.Producers.FindAsync(id);
            if (existingProducer != null)
            {
                existingProducer.FullName = producer.FullName;
                existingProducer.ProfilePictureURL = producer.ProfilePictureURL;
                existingProducer.Bio = producer.Bio;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var producer = await _context.Producers.FindAsync(id);
            if (producer != null)
            {
                _context.Producers.Remove(producer);
                await _context.SaveChangesAsync();
            }
        }
    }
}
