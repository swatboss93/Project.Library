using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using Project.Library.Publishers.Dtos;

namespace Project.Library.Publishers
{
    public class PublisherAppService : IPublisherAppService
    {
        private readonly IPublisherManage _publisherManage;
        private readonly IRepository<Publisher, Guid> _publisherRepository;
        private readonly IAbpSession _abpSession;

        public PublisherAppService(IPublisherManage publisherManage, IRepository<Publisher, Guid> publisherRepository, IAbpSession abpSession)
        {
            _publisherManage = publisherManage;
            _publisherRepository = publisherRepository;
            _abpSession = abpSession;   
        }

        public void DeletePublisher(EntityDto<Guid> input)
        {
            _publisherManage.Delete(input.Id);
        }

        public async Task<IListResult<PublisherDto>> GetAllPublisher()
        {
            var result = await _publisherRepository.GetAllListAsync();
            
            var list = new HashSet<PublisherDto>();
            foreach (var item in result)
            {
                list.AddIfNotContains(PublisherDto.MaptoDto(item));
            }

            return new ListResultDto<PublisherDto>(list.ToList());
        }

        public PublisherDto GetDetail(EntityDto<Guid> input)
        {
            var result = _publisherRepository.GetAll().FirstOrDefault(x => x.Id == input.Id);

            return result.MapTo<PublisherDto>();
        }

        public Task<Publisher> InsertNewPublisher(PublisherDto input)
        {
            var publisher = Publisher.Create(input.Name, input.Address);
            var publisherResult = _publisherManage.Create(publisher);

            return publisherResult;
        }

        public PublisherDto UpdatePublisher(Publisher input)
        {
            var publisherResult = _publisherRepository.Update(input);

            return publisherResult.MapTo<PublisherDto>();
        }
    }
}