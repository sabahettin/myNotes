using Domain.Entities;
using MediatR;
using TS.Result;

namespace Application.Features.Categories.GetAllCategory
{
    public sealed record GetAllCategoryQuery() : IRequest<Result<List<Category>>>;
}
