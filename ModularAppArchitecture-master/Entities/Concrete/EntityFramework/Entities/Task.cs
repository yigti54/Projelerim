using Core.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Concrete.EntityFramework.Entities
{
    [Table("Task")]
    public class Task : IEntity
    {
        [Key]
        public int Id { get; set; }

        public Guid UserId { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        public DateTime DueDate { get; set; }

        public bool IsCompleted { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
