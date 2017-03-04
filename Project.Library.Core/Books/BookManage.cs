using System;
using System.Threading.Tasks;
using Abp.Domain.Repositories;

namespace Project.Library.Books
{
    public class BookManage : IBookManage
    {
        private readonly IRepository<Book, Guid> _bookRepository;

        public BookManage(IRepository<Book, Guid> bookRepository)
        {
            _bookRepository = bookRepository;   
        }

        public Task<Book> Create(Book input)
        {
            var bookResult = _bookRepository.InsertAsync(input);
            return bookResult;
        }
        
        public Task<Book> Update(Book input)
        {
            var book = _bookRepository.UpdateAsync(input);
            return book;
        }

        public void Delete(Guid id)
        {
            _bookRepository.Delete(id);
        }
    }
}