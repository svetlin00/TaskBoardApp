﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using TaskBoardApp.Web.ViewModels.Board;
using static TaskBoardApp.Common.EntityValidationConstants.Task;
namespace TaskBoardApp.Web.ViewModels.Task
{
    public class TaskToEdintViewModel
    {
     
        
            [Required]
            [StringLength(TitleMaxLEnght, MinimumLength = TitleMinLenght, ErrorMessage = TitleErrorMassege)]
            public string Title { get; set; } = null!;

            [Required]
            [StringLength(DescriptionMaxLenght, MinimumLength = DescriptionMinLenght, ErrorMessage = DescriptionErrorMassege)]
            public string Description { get; set; } = null!;
            [Display(Name = "Board")]
            public int BoardName { get; set; }

            public IEnumerable<BoardSelectViewModel>? Boards { get; set; }
        
    }
}
