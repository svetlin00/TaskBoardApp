using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using TaskBoardApp.Data;
using TaskBoardApp.Extensions;
using TaskBoardApp.Services;
using TaskBoardApp.Services.Interfaces;
using TaskBoardApp.Web.ViewModels.Board;
using TaskBoardApp.Web.ViewModels.Task;


namespace TaskBoardApp.Controllers
{
    [Authorize]
    public class TaskController : Controller
    {



        private readonly IBoardService boardService;
        private readonly ITaskService taskService;

        public TaskController(IBoardService boardService, ITaskService taskService)
        {
            this.boardService = boardService;
            this.taskService = taskService;

        }



        [HttpGet]
        public async Task<IActionResult> Create()
        {
            TaskFourmModel viewmodel = new TaskFourmModel()
            {
                Boards = await this.boardService.AllForSelectAsync()
            };

            return View(viewmodel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskFourmModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Boards = await this.boardService.AllForSelectAsync();
                return this.View(model);
            }
            bool exist = await this.boardService.ExistByIdAsync(model.BoardId);

            if (!exist)
            {
                ModelState.AddModelError(nameof(model.BoardId), "Selected board id dont exist");
                model.Boards = await this.boardService.AllForSelectAsync();
                return this.View(model);
            }
            string userId = this.User.GetId();

            await this.taskService.AddAsync(userId, model);
            return this.RedirectToAction("All", "Board");
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            try
            {
                TaskDetailsViewModel taskDetailsViewModel = await this.taskService.ViewDetailsAsync(id);
                return View(taskDetailsViewModel);
            }
            catch (Exception)
            {

                return this.RedirectToAction("All", "Board");
            }
        }


        public async Task<IActionResult> Edit(string id)
        {
            TaskFourmModel model = await this.taskService.GetTaskToEditAsync(id);


            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, TaskFourmModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }
            try
            {
                await this.taskService.EditByIdAsync(id, model);
                return this.RedirectToAction("All", "Board");
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Unexpected error");
                return View(model);
            }
        }
        public async Task<IActionResult> Delete(string id)
        {
            TaskViewModel taskView = await taskService.GetTaskViewModelByIdAsync(id);
            if (taskView == null)
            {
                return this.RedirectToAction("All", "Board");
            }
            else
            {
                return View(taskView);
            }


        }
        [HttpPost]
        public async Task<IActionResult> Delete(TaskViewModel taskView)
        {
           await taskService.DeleteByIdAsync(taskView);
            
           return this.RedirectToAction("All", "Board");
        }

    }
}
