using System;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities.Auditing;

namespace Project.Library.Authors.Dtos
{
    [AutoMapFrom(typeof(Author))]
    public class AuthorDto : FullAuditedEntityDto<Guid>
    {
        public virtual String FirstName { get; set; }
        public virtual String LastName { get; set; }
        public virtual DateTime BirthDate { get; set; }

        public virtual int TenantId { get; set; }

        public static AuthorDto MaptoDto(Author item)
        {
            var dto = item.MapTo<AuthorDto>();
            dto.FirstName = item.FirstName;
            dto.LastName = item.LastName;
            dto.BirthDate = item.BirthDate;
            dto.TenantId = item.TenantId;

            return dto;
        }
    }
}