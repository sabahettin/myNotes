using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace Application.Features.Categories.UpdateCategory
{
    public sealed record UpdateCategoryCommand(
        Guid Id,
        string CategoryName) : IRequest<Result<string>>;
}
