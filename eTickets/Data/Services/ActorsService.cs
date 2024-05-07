using eTickets.Data.Enums;
using eTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Data.Services
{
    public class ActorsService : IActorsService
    {
        //also injection for the data Actors to manipulate the database
        private readonly AppDbContext _context;
        //inject
        public ActorsService(AppDbContext context)
        {
            _context = context;
        }
        //injection complete

        
        public void Add(Actor actor)
        {
            throw new NotImplementedException();
        }

        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Actor>> GetAll()
        {
            var result =await _context.Actors.ToListAsync();
            return result;
        }

        public Actor GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Actor Update(int Id, Actor newActor)
        {
            throw new NotImplementedException();
        }
    }
}
