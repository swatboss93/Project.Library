using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Project.Library.Authors;
using Project.Library.Publishers;

namespace Project.Library.Books
{
    [Table("TwBook")]
    public class Book : FullAuditedEntity<Guid>, ISoftDelete
    {
        [Required]
        [StringLength(120)]
        public virtual String Title { get; set; }

        [Required]
        [StringLength(120)]
        public virtual String ISBN { get; set; }

        [Required]
        public virtual Author Author { get; set; }

        [Required]
        public virtual Publisher Publisher { get; set; }

        
        public static Book Create(string title, string isbn, Author author, Publisher publisher)
        {
            var Book = new Book
            {
                Id = Guid.NewGuid(),
                Title = title,
                ISBN = isbn,
                Author = author,
                Publisher = publisher
            };

            return Book;
        }
    }
}