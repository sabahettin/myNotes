using Application.Features.Categories.CreateCategory;
using Application.Features.Categories.DeleteCategoryByIdCommand;
using Application.Features.Categories.GetAllCategory;
using Application.Features.Categories.UpdateCategory;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.Abstractions;

namespace WebApi.Controllers
{
    public sealed class CategoriesController : ApiController
    {
        public CategoriesController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> GetAll(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode,response);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteById(DeleteCategoryByIdCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
    }
}
