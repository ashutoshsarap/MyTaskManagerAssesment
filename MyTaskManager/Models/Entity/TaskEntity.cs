using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyTaskManager.Models.Entity
{
    public class TaskEntity
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public PriorityEnum Priority { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        [ValidateNever]
        public CategoryEntity Category { get; set; }

        //public string ApplicationUserId { get; set; }
        //[ForeignKey("ApplicationUserId")]
        //[ValidateNever]
        //public ApplicationUserEntity ApplicationUser { get; set; }
    }
}
