using System;
using System.Threading.Tasks;
using Abp.Domain.Repositories;

namespace Project.Library.Authors
{
    public class PersonManage : IAuthorManage
    {
        private readonly IRepository<Author, Guid> _authorRepository;

        public PersonManage(IRepository<Author, Guid> authorRepository)
        {
            _authorRepository = authorRepository;   
        }

        public Task<Author> Create(Author input)
        {
            var authorResult = _authorRepository.InsertAsync(input);
            return authorResult;
        }
        
        public Task<Author> Update(Author input)
        {
            var author = _authorRepository.UpdateAsync(input);
            return author;
        }

        public void Delete(Guid id)
        {
            _authorRepository.Delete(id);
        }
    }
}