﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskBoardApp.Data.Models
{
    public class HomeBoardModel
    {
        public string BoardName { get; set; } = null!;
        public int TaskCount { get; set; }
    }
}
