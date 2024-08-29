using Domain.Entities;
using Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace Application.Features.Notes.GetAllNote
{
    internal sealed class GetAllNoteQueryHandler(INoteRepository noteRepository) : IRequestHandler<GetAllNoteQuery, Result<List<Note>>>
    {
        public async Task<Result<List<Note>>> Handle(GetAllNoteQuery request, CancellationToken cancellationToken)
        {
            List<Note> note = await noteRepository.GetAll().ToListAsync();
            return note;
        }
    }
}
