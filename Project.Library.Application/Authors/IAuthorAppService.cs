using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Project.Library.Authors.Dtos;

namespace Project.Library.Authors
{
    public interface IAuthorAppService : IApplicationService
    {
        Task<Author> InsertNewaAuthor(AuthorDto input);
        AuthorDto UpdateAuthor(AuthorDto input);
        void DeleteAuthor(EntityRequestInput input);
        Task<IListResult<AuthorDto>> GetAllAuthor();
        AuthorDto GetDetail(EntityRequestInput<Guid> input);
    }
}