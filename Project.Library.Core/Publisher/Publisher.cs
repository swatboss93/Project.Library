using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace Project.Library.Publishers
{
    [Table("TwPublisher")]
    public class Publisher : FullAuditedEntity<Guid>, ISoftDelete
    {
        [Required]
        [StringLength(120)]
        public virtual String Name { get; set; }

        [Required]
        [StringLength(120)]
        public virtual String Address { get; set; }

        public static Publisher Create(string name, string address)
        {
            var publisher = new Publisher
            {
                Id = Guid.NewGuid(),
                Name = name,
                Address = address
            };

            return publisher;
        }
    }
}