using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TaskBoardApp.Data;
using TaskBoardApp.Data.Models;
using TaskBoardApp.Services.Interfaces;
using TaskBoardApp.Web.ViewModels.Home;

namespace TaskBoardApp.Services
{
    public class HomeService : IHomeService
    {
        private readonly ApplicationDbContext dbContext;

        public HomeService(ApplicationDbContext dbContext) 
        {
            this.dbContext = dbContext;
        }
        public  List <HomeBoardModel> GetTaskCountOfOwner()
        {

          throw new NotImplementedException();
        }
    }
}
