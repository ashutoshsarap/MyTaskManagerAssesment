using System.ComponentModel.DataAnnotations;

namespace MyTaskManager.Models.Entity
{
    public class ApplicationUserEntity
    {

        [Key]
        public string Id { get; set; }
        public string UserName { get; set; }
        
    }
}
