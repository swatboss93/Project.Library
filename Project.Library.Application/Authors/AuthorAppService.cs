using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using Project.Library.Authors.Dtos;

namespace Project.Library.Authors
{
    public class AuthorAppService : IAuthorAppService
    {
        private readonly IAuthorManage _authorManage;
        private readonly IRepository<Author, Guid> _authorRepository;
        private readonly IAbpSession _abpSession;

        public AuthorAppService(IAuthorManage authorManage, IRepository<Author, Guid> authorRepository, IAbpSession abpSession)
        {
            _authorManage = authorManage;
            _authorRepository = authorRepository;
            _abpSession = abpSession;   
        }

        public void DeleteAuthor(EntityDto<Guid> input)
        {
            _authorManage.Delete(input.Id);
        }

        public async Task<IListResult<AuthorDto>> GetAllAuthor()
        {
            var result = await _authorRepository.GetAllListAsync();
            
            var list = new HashSet<AuthorDto>();
            foreach (var item in result)
            {
                list.AddIfNotContains(AuthorDto.MaptoDto(item));
            }

            return new ListResultDto<AuthorDto>(list.ToList());
        }

        public AuthorDto GetDetail(EntityDto<Guid> input)
        {
            var result = _authorRepository.GetAll().FirstOrDefault(x => x.Id == input.Id);

            return result.MapTo<AuthorDto>();
        }

        public Task<Author> InsertNewAuthor(AuthorDto input)
        {
            var author = Author.Create(input.FirstName, input.LastName, input.TenantId);
            var authorResult = _authorManage.Create(author);

            return authorResult;
        }


        public AuthorDto UpdateAuthor(Author input)
        {
            var authorResult = _authorRepository.Update(input);

            return authorResult.MapTo<AuthorDto>();
        }
    }
}