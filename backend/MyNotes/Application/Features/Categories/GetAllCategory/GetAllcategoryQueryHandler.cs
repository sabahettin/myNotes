using Domain.Entities;
using Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace Application.Features.Categories.GetAllCategory
{
    internal sealed class GetAllcategoryQueryHandler(ICategoryRepository categoryRepository) : IRequestHandler<GetAllCategoryQuery, Result<List<Category>>>
    {
        public async Task<Result<List<Category>>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            List<Category> category = await categoryRepository.GetAll().OrderBy(x => x.CategoryName).ToListAsync();
            return category;

        }
    }
}
