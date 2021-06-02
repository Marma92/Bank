using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bankdata.Events
{
    class DomainEvent
    {
        Account_History accountHistory;

        public DomainEvent domainEvent(Account_History accountHistory, )
        {
            this.accountHistory = accountHistory;
        }
    }
}
