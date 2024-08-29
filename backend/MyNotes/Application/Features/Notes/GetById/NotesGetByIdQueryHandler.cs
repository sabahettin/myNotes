using Domain.Entities;
using Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace Application.Features.Notes
{
    internal sealed class NotesGetByIdQueryHandler(INoteRepository _noteRepository) : IRequestHandler<NotesGetByIdQuery, Result<Note>>
    {
        public async Task<Result<Note>> Handle(NotesGetByIdQuery request, CancellationToken cancellationToken)
        {
            Note note = await _noteRepository.Where(x => x.Id == request.Id).FirstOrDefaultAsync();

            if (note == null)
            {
                return Result<Note>.Failure("Note not found");
            }

            return (note);
        }
    }
}
