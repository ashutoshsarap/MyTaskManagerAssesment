using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyTaskManager.Models;
using MyTaskManager.Models.Entity;

namespace MyTaskManager.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<TaskEntity> TaskItems { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<TaskEntity>().HasData(
                new TaskEntity
                {
                    Id = 1,
                    Title = "Make a webapp",
                    Description = "Make a webapp using MVC",
                    DueDate = DateTime.Now.AddDays(7),
                    Priority = PriorityEnum.High,
                    CategoryId = 1,
                },
                new TaskEntity
                {
                    Id = 2,
                    Title = "Learn C#",
                    Description = "Learn C# programming language",
                    DueDate = DateTime.Now.AddDays(14),
                    Priority = PriorityEnum.Medium,
                    CategoryId = 2,
                },
                new TaskEntity
                {
                    Id = 3,
                    Title = "Go to the gym",
                    Description = "Go to the gym and workout",
                    DueDate = DateTime.Now.AddDays(1),
                    Priority = PriorityEnum.Low,
                    CategoryId = 3,
                }
            );

            builder.Entity<CategoryEntity>().HasData(
                    new CategoryEntity
                    {
                        Id = 1,
                        Name = "Work"
                    },
                    new CategoryEntity
                    {
                        Id = 2,
                        Name = "Learning"
                    },
                    new CategoryEntity
                    {
                        Id = 3,
                        Name = "Health"
                    }
                );

        }
    }
}
