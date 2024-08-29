using Application.Features.Notes;
using Domain.Entities;
using MediatR;
using TS.Result;

namespace Application.Features.Notes
{
    public sealed record NotesGetByIdQuery(Guid Id) : IRequest<Result<Note>>;

}
