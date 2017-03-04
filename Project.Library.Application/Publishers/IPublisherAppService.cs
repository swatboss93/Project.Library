using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Project.Library.Publishers.Dtos;

namespace Project.Library.Publishers
{
    public interface IPublisherAppService : IApplicationService
    {
        Task<Publisher> InsertNewPublisher(PublisherDto input);
        PublisherDto UpdatePublisher(Publisher input);
        void DeletePublisher(EntityDto<Guid> input);
        Task<IListResult<PublisherDto>> GetAllPublisher();
        PublisherDto GetDetail(EntityDto<Guid> input);
    }
}