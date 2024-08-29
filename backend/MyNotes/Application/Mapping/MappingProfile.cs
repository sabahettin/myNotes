using Application.Features.Categories.CreateCategory;
using Application.Features.Categories.DeleteCategoryByIdCommand;
using Application.Features.Categories.UpdateCategory;
using Application.Features.Notes.CreateNote;
using Application.Features.Notes.DeleteNote;
using Application.Features.Notes.UpdateNote;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping
{
    public sealed class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateCategoryCommand, Category>();
            CreateMap<UpdateCategoryCommand, Category>();
            CreateMap<DeleteCategoryByIdCommand, Category>();
            CreateMap<CreateNoteCommand, Note>();
            CreateMap<UpdateNoteCommand, Note>();
            CreateMap<DeleteNoteCommand, Note>();
        }
    }
}
