﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public static class Utils
    {
        public static string GetPolishCharactersSetRegex()
        {
            return "A-Za-zżźćńółęąśŻŹĆĄŚĘŁÓŃ";
        }
    }
}
