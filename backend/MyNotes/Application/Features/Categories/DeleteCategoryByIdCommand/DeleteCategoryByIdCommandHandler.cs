using Domain.Entities;
using Domain.Repositories;
using GenericRepository;
using MediatR;
using TS.Result;

namespace Application.Features.Categories.DeleteCategoryByIdCommand
{
    internal sealed class DeleteCategoryByIdCommandHandler(
        ICategoryRepository categoryRepository,
        IUnitOfWork unitOfWork) : IRequestHandler<DeleteCategoryByIdCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(DeleteCategoryByIdCommand request, CancellationToken cancellationToken)
        {
            Category? category = await categoryRepository.GetByExpressionAsync(x=>x.Id == request.Id, cancellationToken);
            if (category == null)
            {
                return Result<string>.Failure("Category is not found!");
            }

            categoryRepository.Delete(category);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return "Category delete is successful!";
        }
    }
}
