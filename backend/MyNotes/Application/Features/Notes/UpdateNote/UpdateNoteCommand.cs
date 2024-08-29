using MediatR;
using TS.Result;

namespace Application.Features.Notes.UpdateNote
{
    public sealed record UpdateNoteCommand(
        Guid Id,
        string Title,
        string Description,
        string Priority,
        Guid CategoryId) : IRequest<Result<string>>;
}
