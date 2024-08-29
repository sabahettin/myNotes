using Domain.Entities;
using Domain.Repositories;
using GenericRepository;
using Infrastructure.Context;

namespace Infrastructure.Repositories
{
    internal sealed class CategoryRepository : Repository<Category, ApplicationDbContext>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
