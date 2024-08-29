using MediatR;
using TS.Result;

namespace Application.Features.Categories.CreateCategory
{
    public sealed record CreateCategoryCommand(
        string CategoryName) : IRequest<Result<string>>;
}
