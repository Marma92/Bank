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

        public DomainEvent (Account_History accountHistory)
        {
            this.accountHistory = accountHistory;

        }

        public void Push()
        {
            using (var context = new bankEntities1())
            {
                context.Account_History.Add(accountHistory);
                context.SaveChanges();
            }
        }
    }
}
