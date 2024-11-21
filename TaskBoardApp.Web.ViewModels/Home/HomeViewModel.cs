
using TaskBoardApp.Data.Models;

namespace TaskBoardApp.Web.ViewModels.Home
{
    public class HomeViewModel
    {
        public HomeViewModel() 
        {
            List<HomeBoardModel> BoardsWithTaskCount = new List<HomeBoardModel>();
        }
     
        public int AllTaskCount { get; set; }
        public int UserTasksCount { get; set; }
        public List<HomeBoardModel> BoardsWithTaskCount { get; set; } = null!;
    }
}
