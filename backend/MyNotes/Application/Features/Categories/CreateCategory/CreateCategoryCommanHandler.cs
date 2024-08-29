using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using GenericRepository;
using MediatR;
using TS.Result;

namespace Application.Features.Categories.CreateCategory
{
    internal sealed class CreateCategoryCommanHandler(
        ICategoryRepository categoryRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper) : IRequestHandler<CreateCategoryCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            Category category = mapper.Map<Category>(request);
            await categoryRepository.AddAsync(category, cancellationToken);
            var res  = await unitOfWork.SaveChangesAsync(cancellationToken);


            return "Category create is successful";
        }
    }

}
