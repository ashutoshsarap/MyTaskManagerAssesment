using System.ComponentModel.DataAnnotations;

namespace MyTaskManager.Models.ViewModels
{
    public class TaskVM
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage ="Description should be less than 100 letters")]
        public string Description { get; set; }
        
        public DateTime DueDate { get; set; }
        [Required(ErrorMessage ="Priority is required")]
        public PriorityEnum Priority { get; set; }
        public int CategoryId { get; set; }
    }
}
