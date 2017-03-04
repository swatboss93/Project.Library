using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using Project.Library.Authors;
using Project.Library.Book;
using Project.Library.Books.Dtos;
using Project.Library.Publishers;

namespace Project.Library.Books
{
    public class BookAppService : IBookAppService
    {
        private readonly IBookManage _bookManage;
        private readonly IRepository<Book, Guid> _bookRepository;
        private readonly IRepository<Author, Guid> _authorRepository;
        private readonly IRepository<Publisher, Guid> _publisherRepository;
        private readonly IAbpSession _abpSession;

        public BookAppService(IBookManage bookManage, IRepository<Book, Guid> bookRepository, IRepository<Author, Guid> authorRepository, IRepository<Publisher, Guid> publisherRepository, IAbpSession abpSession)
        {
            _bookManage = bookManage;
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
            _publisherRepository = publisherRepository;
            _abpSession = abpSession;   
        }

        public void DeleteBook(EntityDto<Guid> input)
        {
            _bookManage.Delete(input.Id);
        }

        public async Task<IListResult<BookDto>> GetAllBook()
        {
            var result = await _bookRepository.GetAllListAsync();
            
            var list = new HashSet<BookDto>();
            foreach (var item in result)
            {
                list.AddIfNotContains(BookDto.MaptoDto(item));
            }

            return new ListResultDto<BookDto>(list.ToList());
        }

        public BookDto GetDetail(EntityDto<Guid> input)
        {
            var result = _bookRepository.GetAll().FirstOrDefault(x => x.Id == input.Id);

            return result.MapTo<BookDto>();
        }

        public Task<Book> InsertNewBook(BookDto input)
        {
            var author = _authorRepository.GetAll().FirstOrDefault(x => x.Id == input.Author.Id);
            var publisher = _publisherRepository.GetAll().FirstOrDefault(x => x.Id == input.Publisher.Id);
            var book = Book.Create(input.Title, input.ISBN, author, publisher);
            var bookResult = _bookManage.Create(book);

            return bookResult;
        }

        public BookDto UpdateBook(Book input)
        {
            input.Author = _authorRepository.GetAll().FirstOrDefault(x => x.Id == input.Author.Id);
            input.Publisher = _publisherRepository.GetAll().FirstOrDefault(x => x.Id == input.Publisher.Id);
            var bookResult = _bookRepository.Update(input);

            return bookResult.MapTo<BookDto>();
        }
    }
}