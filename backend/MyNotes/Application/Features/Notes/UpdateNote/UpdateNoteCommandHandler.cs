using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using GenericRepository;
using MediatR;
using TS.Result;

namespace Application.Features.Notes.UpdateNote
{
    internal sealed class UpdateNoteCommandHandler(
        INoteRepository noteRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper) : IRequestHandler<UpdateNoteCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(UpdateNoteCommand request, CancellationToken cancellationToken)
        {
            Note? note = await noteRepository.GetByExpressionWithTrackingAsync(x => x.Id == request.Id, cancellationToken);
            if (note == null)
            {
                return Result<string>.Failure("Note not found!");
            }

            mapper.Map(request, note);

            noteRepository.Update(note);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return "Note update is successful!";
        }
    }
}
