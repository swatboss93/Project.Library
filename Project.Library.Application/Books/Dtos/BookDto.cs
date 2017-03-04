using System;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Project.Library.Authors;
using Project.Library.Publishers;

namespace Project.Library.Books.Dtos
{
    [AutoMapFrom(typeof(Book))]
    public class BookDto : FullAuditedEntityDto<Guid>
    {
        public virtual String Title { get; set; }
        public virtual String ISBN { get; set; }
        public virtual Author Author { get; set; }
        public virtual Publisher Publisher { get; set; }
        public static BookDto MaptoDto(Book item)
        {
            var dto = item.MapTo<BookDto>();
            dto.Title = item.Title;
            dto.ISBN = item.ISBN;
            dto.Author = item.Author;
            dto.Publisher = item.Publisher;
            return dto;
        }
    }
}