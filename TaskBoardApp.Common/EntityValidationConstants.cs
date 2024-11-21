using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TaskBoardApp.Common
{
    public static class EntityValidationConstants
    {
        public static  class Task 
        {
            public const int TitleMinLenght = 5;
            public const int TitleMaxLEnght = 70;
            public const string TitleErrorMassege = "Title should be at lest {2} charecters long";

            public const int DescriptionMinLenght = 10;
            public const int DescriptionMaxLenght = 1000;
            public const string DescriptionErrorMassege = "Description should be at lest {2} charecters long";
        }


        public static class Board
        {
            public const int BoardMaxName = 30;
            public const int BoardMinName = 3;
        }

    }



}

