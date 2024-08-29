using Domain.Entities;
using Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace Application.Features.Notes
{
    internal sealed class NotesByCategoryIdQueryHandler(INoteRepository noteRepository) : IRequestHandler<NotesByCategoryIdQuery, Result<List<Note>>>
    {
        public async Task<Result<List<Note>>> Handle(NotesByCategoryIdQuery request, CancellationToken cancellationToken)
        {
            List<Note> note  = await noteRepository.Where(x=>x.CategoryId == request.CategoryId).ToListAsync();
            return note;
        }
    }
}
