﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sec5
{
    static class Levels
    {
        public static int[,] zeros = new int[,] 
        {
            { 0,0,0,0,0,0,0,0,0, },
            { 0,0,0,0,0,0,0,0,0, },
            { 0,0,0,0,0,0,0,0,0, },
            { 0,0,0,0,0,0,0,0,0, },
            { 0,0,0,0,0,0,0,0,0, },
            { 0,0,0,0,0,0,0,0,0, },
            { 0,0,0,0,0,0,0,0,0, },
            { 0,0,0,0,0,0,0,0,0, },
            { 0,0,0,0,0,0,0,0,0, },
        };


        public static int[,] easy = new int[,]
           {
            { 3, 0, 6, 5, 0, 8, 4, 0, 0 },
            { 5, 2, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 8, 7, 0, 0, 0, 0, 3, 1 },

            { 0, 0, 3, 0, 1, 0, 0, 8, 0 },
            { 9, 0, 0, 8, 6, 3, 0, 0, 5 },
            { 0, 5, 0, 0, 9, 0, 6, 0, 0 },

            { 1, 3, 0, 0, 0, 0, 2, 5, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 7, 4 },
            { 0, 0, 5, 2, 0, 6, 3, 0, 0 },
           };

        public static int[,] midum = new int[,] 
        {   { 0,0,4, 0,0,7, 8,3,0, },
            { 0,1,0, 9,3,0, 7,0,5, },
            { 3,5,7, 0,0,4, 1,0,0, },

            { 0,3,0, 0,0,2, 9,8,4, },
            { 0,0,0, 0,8,1, 0,0,0, },
            { 0,2,0, 0,0,0, 6,0,0, },

            { 4,7,3, 2,0,8, 0,0,1, },
            { 2,6,0, 1,0,0, 0,7,8, },
            { 5,0,1, 6,0,0, 4,0,0, },
        };

       
    }
}
