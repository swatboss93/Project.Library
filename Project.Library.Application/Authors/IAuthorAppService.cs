using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Project.Library.Authors.Dtos;

namespace Project.Library.Authors
{
    public interface IAuthorAppService : IApplicationService
    {
        Task<Author> InsertNewAuthor(AuthorDto input);
        AuthorDto UpdateAuthor(Author input);
        void DeleteAuthor(EntityDto<Guid> input);
        Task<IListResult<AuthorDto>> GetAllAuthor();
        AuthorDto GetDetail(EntityDto<Guid> input);
    }
}