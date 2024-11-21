using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TaskBoardApp.Services.Interfaces;
using TaskBoardApp.Data;
using TaskBoardApp.Web.ViewModels.Home;
using TaskBoardApp.Data.Models;
using Microsoft.EntityFrameworkCore;


namespace TaskBoardApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        private readonly IHomeService homeService;

        public HomeController(IHomeService homeService, ApplicationDbContext dbContext) 
        {
            this.homeService = homeService;
            this.dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            var taskBoard = await dbContext.Boards.Select(b => b.Name).Distinct().ToListAsync();
            List<HomeBoardModel> taskCount = new List<HomeBoardModel>();
            foreach (var boardName in taskBoard)
            {
                var taskInBoard = await dbContext.Tasks.Where(t => t.Board.Name == boardName).CountAsync();
                taskCount.Add(new HomeBoardModel()
                {
                    BoardName = boardName,
                    TaskCount = taskInBoard,
                });
            }

            int userTaskCount = -1;

            if (User.Identity.IsAuthenticated)
            {
                var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                userTaskCount = dbContext.Tasks.Where(t => t.OwnerId == currentUserId).Count();
            }

            HomeViewModel model = new HomeViewModel()
            {
                AllTaskCount =  await dbContext.Tasks.CountAsync(),
                BoardsWithTaskCount =  taskCount,
                UserTasksCount = userTaskCount
            };

            return View(model);
        }
        

        
    


    }
}
