using Domain.Entities;
using MediatR;
using TS.Result;

namespace Application.Features.Notes.GetAllNote
{
    public sealed record GetAllNoteQuery() : IRequest<Result<List<Note>>>;
}
