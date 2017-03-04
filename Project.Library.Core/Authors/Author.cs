using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace Project.Library.Authors
{
    [Table("TwAuthor")]
    public class Author : FullAuditedEntity<Guid>, ISoftDelete
    {
        [Required]
        [StringLength(120)]
        public virtual String FirstName { get; set; }

        [Required]
        [StringLength(120)]
        public virtual String LastName { get; set; }

        public int TenantId { get; set; }

        public static Author Create(string firstName, string lastName, int tenantId)
        {
            var author = new Author
            {
                Id = Guid.NewGuid(),
                FirstName = firstName,
                LastName = lastName,
                TenantId = tenantId
            };

            return author;
        }
    }
}