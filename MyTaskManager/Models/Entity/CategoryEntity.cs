using System.ComponentModel.DataAnnotations;

namespace MyTaskManager.Models.Entity
{
    public class CategoryEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
