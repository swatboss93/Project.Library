using System;
using System.Threading.Tasks;
using Abp.Domain.Services;

namespace Project.Library.Publishers
{
    public interface IPublisherManage : IDomainService
    {
        Task<Publisher> Create(Publisher input);
        Task<Publisher> Update(Publisher input);
        void Delete(Guid id);
    }
}