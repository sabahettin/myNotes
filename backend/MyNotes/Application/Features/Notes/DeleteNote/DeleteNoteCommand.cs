using MediatR;
using TS.Result;

namespace Application.Features.Notes.DeleteNote
{
    public sealed record DeleteNoteCommand(Guid Id) : IRequest<Result<string>>;
}
