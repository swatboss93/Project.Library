using System;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace Project.Library.Authors.Dtos
{
    [AutoMapFrom(typeof(Author))]
    public class AuthorDto : FullAuditedEntityDto<Guid>
    {
        public virtual String FirstName { get; set; }
        public virtual String LastName { get; set; }
        public virtual int TenantId { get; set; }

        public static AuthorDto MaptoDto(Author item)
        {
            var dto = item.MapTo<AuthorDto>();
            dto.FirstName = item.FirstName;
            dto.LastName = item.LastName;
            dto.TenantId = item.TenantId;
            return dto;
        }
    }
}