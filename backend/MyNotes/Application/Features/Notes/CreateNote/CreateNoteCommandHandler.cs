using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using GenericRepository;
using MediatR;
using TS.Result;

namespace Application.Features.Notes.CreateNote
{
    internal sealed class CreateNoteCommandHandler(
        INoteRepository noteRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper) : IRequestHandler<CreateNoteCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(CreateNoteCommand request, CancellationToken cancellationToken)
        {
            Note note = mapper.Map<Note>(request);
            await noteRepository.AddAsync(note, cancellationToken);
            var res = await unitOfWork.SaveChangesAsync(cancellationToken);

            return "Note create is successful";
        }
    }
}
