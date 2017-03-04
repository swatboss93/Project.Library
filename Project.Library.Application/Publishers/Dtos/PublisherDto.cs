using System;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace Project.Library.Publishers.Dtos
{
    [AutoMapFrom(typeof(Publisher))]
    public class PublisherDto : FullAuditedEntityDto<Guid>
    {
        public virtual String Name { get; set; }
        public virtual String Address { get; set; }

        public static PublisherDto MaptoDto(Publisher item)
        {
            var dto = item.MapTo<PublisherDto>();
            dto.Name = item.Name;
            dto.Address = item.Address;

            return dto;
        }
    }
}