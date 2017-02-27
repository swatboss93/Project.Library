using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace Project.Library.Authors
{
    [Table("TwAuthor")]
    public class Author : FullAuditedEntity<Guid>, IMustHaveTenant, ISoftDelete
    {
        [Required]
        [StringLength(120)]
        public virtual String FirstName { get; set; }

        [Required]
        [StringLength(120)]
        public virtual String LastName { get; set; }

        /*[DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]*/
        public virtual DateTime BirthDate  { get; set; }

        public int TenantId { get; set; }

        public static Author Create(string firstName, string lastName, DateTime birthDate, int tenantId)
        {
            var author = new Author
            {
                Id = Guid.NewGuid(),
                FirstName = firstName,
                LastName = lastName,
                BirthDate = birthDate,
                TenantId = tenantId
            };

            return author;
        }
    }
}