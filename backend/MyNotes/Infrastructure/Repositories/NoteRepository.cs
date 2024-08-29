using Domain.Entities;
using Domain.Repositories;
using GenericRepository;
using Infrastructure.Context;

namespace Infrastructure.Repositories
{
    internal sealed class NoteRepository : Repository<Note, ApplicationDbContext>, INoteRepository
    {
        public NoteRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
