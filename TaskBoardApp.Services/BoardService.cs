
using TaskBoardApp.Services.Interfaces;
using TaskBoardApp.Web.ViewModels.Board;
using TaskBoardApp.Data;
using TaskBoardApp.Web.ViewModels.Task;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace TaskBoardApp.Services
{
    public class BoardService : IBoardService
    {
        private readonly ApplicationDbContext dbContext;
        public BoardService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public async Task<IEnumerable<BoardAllViewModel>> AllAsync()
        {
            IEnumerable<BoardAllViewModel> allBords =  await this.dbContext
                .Boards
                .Select(b => new BoardAllViewModel()
                {
                    Name = b.Name,
                    Tasks =  b.Tasks
                    .Select(t =>  new TaskViewModel() 
                    { 
                        Id = t.Id.ToString(),
                        Title = t.Title
                        , Description = t.Description
                        , Owner = t.Owner.UserName
                    }).ToArray()
                })
                .ToArrayAsync();
                 
            return allBords; 
        }

        public  async Task<IEnumerable<BoardSelectViewModel>> AllForSelectAsync()
        {
            IEnumerable<BoardSelectViewModel> allBoards =  await this.dbContext
                .Boards
                .Select(b => new BoardSelectViewModel() 
                {
                    Id = b.Id,
                    Name = b.Name
                }).ToArrayAsync();
          return allBoards;
        }

        public async Task<bool> ExistByIdAsync(int id)
        {
            bool result = await this.dbContext
                .Boards.AnyAsync(b => b.Id == id);

            return result;
        }
    }
    }
