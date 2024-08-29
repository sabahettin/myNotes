using Domain.Entities;
using MediatR;
using TS.Result;

namespace Application.Features.Notes
{
    public sealed record NotesByCategoryIdQuery(Guid CategoryId) : IRequest<Result<List<Note>>>;

}
