﻿using Dmail.Domain.Repositories;
using Dmail.Dormain.Factories;
using Dmail.Dormain.Repositories;
using Dmail.Presentation.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dmail.Presentation.Menus
{
     public static class MainMenu
     {
        public static void Create()
        {
            MenusPrint.MainMenuPrint();
            int input = MenuInput.GetInput(7);
            switch(input)
            {
                case 1:
                    var a = new IncomingMail(RepositoryFactory.Create<UserRepository>(),RepositoryFactory.Create<MailRepository>());
                    a.Create();
                    break;
                case 2:
                    //SentMail.Create();
                    break;
                case 3:
                    //Spam.Create();
                    break;
                case 4:
                    //var d= new SendNewMail(RepositoryFactory.Create<MailRepository>());
                    //d.Create();
                    break;
                case 5:
                    //SendNewEvent.Create();
                    break;
                case 6:
                    //Settings.Create();  
                    break;
                case 7:
                    EntryMenu.Create();
                    break;
                default: 
                    break; 

            }
        }
     }
}
