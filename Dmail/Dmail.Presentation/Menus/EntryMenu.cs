﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Dmail.Dormain.Factories;
using Dmail.Dormain.Repositories;
using Dmail.Presentation.Actions;
using Dmail.Presentation.Menus;
namespace Dmail.Presentation.Menus
{
    public static class EntryMenu
    {
        public static void Create() 
        {
            MenusPrint.EntryMenuPrint();
            int input=MenuInput.GetInput(3);
            switch (input)
            {
                case 1:
                    new Login(RepositoryFactory.Create<UserRepository>());
                    Login.Create();
                    break;
                case 2:
                    new Registration(RepositoryFactory.Create<UserRepository>());
                    break;
                default:
                    Environment.Exit(0);
                    break;
            }
        }
    }    
}
