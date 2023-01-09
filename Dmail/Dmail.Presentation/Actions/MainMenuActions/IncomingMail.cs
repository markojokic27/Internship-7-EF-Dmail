using Dmail.Domain.Repositories;
using Dmail.Dormain.Repositories;
using Dmail.Presentation.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dmail.Presentation.Actions
{
    public  class IncomingMail
    {
        private readonly MailRepository _mailRepository;
        public IncomingMail(MailRepository mailRepository)
        {
            _mailRepository= mailRepository;
        }
        public void Create()
        {
            MenusPrint.IncomingMailMenuPrint();
            int input = MenuInput.GetInput(4);
            switch(input){
                case 1:
                    
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;

            }

        }
    }
}
