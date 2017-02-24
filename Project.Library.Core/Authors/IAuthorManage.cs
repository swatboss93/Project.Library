using System;
using System.Threading.Tasks;
using Abp.Domain.Services;

namespace Project.Library.Authors
{
    public interface IAuthorManage : IDomainService
    {
        Task<Author> Create(Author input);
        Task<Author> Update(Author input);
        void Delete(Guid id);
    }
}