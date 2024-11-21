using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskBoardApp.Data;
using TaskBoardApp.Data.Models;
using TaskBoardApp.Web.ViewModels.Home;

namespace TaskBoardApp.Services.Interfaces
{
    public interface IHomeService
    {
      

        public List<HomeBoardModel>GetTaskCountOfOwner();

      
    }
}
