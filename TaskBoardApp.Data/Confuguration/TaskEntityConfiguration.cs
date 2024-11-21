using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskBoardApp.Data.Confuguration
{
    internal class TaskEntityConfiguration : IEntityTypeConfiguration<Models.Task>
    {
        public void Configure(EntityTypeBuilder<Models.Task> builder)
        {
            builder.HasOne(t => t.Board)
                .WithMany(b => b.Tasks)
                .HasForeignKey(t => t.BoardId)
                .OnDelete(DeleteBehavior.Restrict);

             ICollection<Models.Task> tasks = GenerateTasks();
            builder.HasData(tasks);
            
        }

       private ICollection<Models.Task> GenerateTasks() 
        { 
            ICollection<Models.Task> tasks = new HashSet<Models.Task>();

            Models.Task task = new Models.Task
            {
                Id = 1,
                Title = "Improve CSS Style",
                Description = "Implem,ent better styling for all public pages",
                CreatedOn = DateTime.Now.AddDays(-200),
                OwnerId = "0fc2235f-9ee7-4a99-bf2b-e4499f5197a6",
                BoardId = 1
            };
            tasks.Add(task);

            task = new Models.Task
            {
                Id= 2,
                Title = "Android Client App",
                Description = "Create Android client app for TaskBoiard RESTful API",
                CreatedOn = DateTime.Now.AddDays(-5),
                OwnerId = "1785e069-6b28-4739-ae99-765dad025557",
                BoardId = 2
            };

            tasks.Add(task);

            task = new Models.Task 
            {   Id=3,
                Title = "Desktop Client App",
                Description = "Create Windows from desktop app client  for TaskBoiard RESTful API",
                CreatedOn = DateTime.Now.AddDays(-1),
                OwnerId = "75d53db7-f7a6-40cf-9a0f-e7e32baca46a",
                BoardId = 3
            };

            tasks.Add(task);

            return tasks;
        }
    }
}
