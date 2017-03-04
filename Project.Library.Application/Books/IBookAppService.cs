using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Project.Library.Books.Dtos;

namespace Project.Library.Book
{
    public interface IBookAppService : IApplicationService
    {
        Task<Books.Book> InsertNewBook(BookDto input);
        BookDto UpdateBook(Books.Book input);
        void DeleteBook(EntityDto<Guid> input);
        Task<IListResult<BookDto>> GetAllBook();
        BookDto GetDetail(EntityDto<Guid> input);
    }
}