using MediatR;
using TS.Result;

namespace Application.Features.Notes.CreateNote
{
    public sealed record CreateNoteCommand(
        string Title,
        string Description,
        string Priority,
        Guid CategoryId) : IRequest<Result<string>>;
}
