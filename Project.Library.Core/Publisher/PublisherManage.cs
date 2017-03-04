using System;
using System.Threading.Tasks;
using Abp.Domain.Repositories;

namespace Project.Library.Publishers
{
    public class PublisherManage : IPublisherManage
    {
        private readonly IRepository<Publisher, Guid> _publisherRepository;

        public PublisherManage(IRepository<Publisher, Guid> publisherRepository)
        {
            _publisherRepository = publisherRepository;   
        }

        public Task<Publisher> Create(Publisher input)
        {
            var publisherResult = _publisherRepository.InsertAsync(input);
            return publisherResult;
        }
        
        public Task<Publisher> Update(Publisher input)
        {
            var publisher = _publisherRepository.UpdateAsync(input);
            return publisher;
        }

        public void Delete(Guid id)
        {
            _publisherRepository.Delete(id);
        }
    }
}