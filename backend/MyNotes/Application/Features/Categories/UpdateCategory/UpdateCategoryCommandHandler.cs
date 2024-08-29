using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using GenericRepository;
using MediatR;
using TS.Result;

namespace Application.Features.Categories.UpdateCategory
{
    internal sealed class UpdateCategoryCommandHandler(
        ICategoryRepository categoryRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper) : IRequestHandler<UpdateCategoryCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            Category? category = await categoryRepository.GetByExpressionWithTrackingAsync(x => x.Id == request.Id, cancellationToken);
            if (category == null)
            {
                return Result<string>.Failure("Category not found!");
            }

            mapper.Map(request, category);

            categoryRepository.Update(category);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return "Category update is successful!";

        }
    }
}
