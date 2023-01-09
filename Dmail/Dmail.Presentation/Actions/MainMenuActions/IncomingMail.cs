using Dmail.Domain.Repositories;
using Dmail.Dormain.Repositories;
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

        }
    }
}
