using Application.Features.Notes.DeleteNote;
using Domain.Entities;
using Domain.Repositories;
using GenericRepository;
using MediatR;
using TS.Result;

internal sealed class DeleteNoteCommandHandler(
    INoteRepository noteRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<DeleteNoteCommand, Result<string>>
{
    public async Task<Result<string>> Handle(DeleteNoteCommand request, CancellationToken cancellationToken)
    {
        Note? note = await noteRepository.GetByExpressionAsync(x => x.Id == request.Id, cancellationToken);
        if (note == null)
        {
            return Result<string>.Failure("Note is not found!");
        }

        noteRepository.Delete(note);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return "Note delete is successful!";
    }
}
