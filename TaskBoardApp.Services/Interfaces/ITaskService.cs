
using TaskBoardApp.Web.ViewModels.Task;

namespace TaskBoardApp.Services.Interfaces
{
    public interface ITaskService
    {
        Task AddAsync(string userId, TaskFourmModel model);
        Task<TaskDetailsViewModel?> ViewDetailsAsync(string id);
        Task<TaskFourmModel> GetTaskToEditAsync(string id);
        Task EditByIdAsync(string id, TaskFourmModel model);
        Task<TaskViewModel> GetTaskViewModelByIdAsync(string id);
        Task DeleteByIdAsync(TaskViewModel model);
    }
}
