
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using TaskBoardApp.Data;
using TaskBoardApp.Services.Interfaces;
using TaskBoardApp.Web.ViewModels.Board;
using TaskBoardApp.Web.ViewModels.Task;
namespace TaskBoardApp.Services
{
    public class TaskService : ITaskService
    {
        private readonly ApplicationDbContext dbContext;
        public TaskService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddAsync(string userId, TaskFourmModel model)
        {
            Data.Models.Task task = new Data.Models.Task()
            {
                Title = model.Title,
                Description = model.Description,
                BoardId = model.BoardId,
                CreatedOn = DateTime.UtcNow,
                OwnerId = userId,
            };

            await this.dbContext.Tasks.AddAsync(task);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(TaskViewModel model)
        {
            Data.Models.Task task = await dbContext.Tasks.FirstAsync(t => t.Id.ToString() == model.Id);
            dbContext.Tasks.Remove(task);
            await this.dbContext.SaveChangesAsync();
            
        }

        public  async Task EditByIdAsync(string id, TaskFourmModel model)
        {

            Data.Models.Task task = await dbContext.Tasks.FirstAsync(t => t.Id.ToString() == id);
            task.Title = model.Title;
            task.Description = model.Description;
            task.BoardId = model.BoardId;
        
           await this.dbContext.SaveChangesAsync();
        }

        public async Task<TaskFourmModel> GetTaskToEditAsync(string id)
        {
            Data.Models.Task task = await dbContext.Tasks.FirstAsync(t => t.Id.ToString() == id);

            TaskFourmModel taskFourm = new TaskFourmModel()
            {
                Title = task.Title,
                Description = task.Description,
                BoardId = task.BoardId,
                Boards = await dbContext.Boards
                .Select(b => new BoardSelectViewModel()
                {
                    Id = b.Id,
                    Name = b.Name
                }).ToArrayAsync()
            };

            return taskFourm;
        }

        public async Task<TaskViewModel> GetTaskViewModelByIdAsync(string id)
        {
            Data.Models.Task task = await dbContext.Tasks.FirstAsync(t => t.Id.ToString() == id);
            TaskViewModel taskViewModel = new TaskViewModel()
            {
               
                Title = task.Title,
                Description = task.Description,
            }; 

            return taskViewModel;
        }

        public async Task<TaskDetailsViewModel?> ViewDetailsAsync(string taskId)
        {
            TaskDetailsViewModel? taskDetails = await dbContext.Tasks.Select(t => new TaskDetailsViewModel
            {
                Id = t.Id.ToString(),
                Title = t.Title,
                Description = t.Description,
                Owner = t.Owner.UserName,
                CreatedOn = t.CreatedOn.ToString("f"),
                Board = t.Board.Name,
            })
            .FirstOrDefaultAsync(t => t.Id == taskId.ToString());

            return taskDetails;
        }
    }
}
