using bankdata.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bankdata.Commands
{
    public class DepositOnAGivenAccount : IBankOperation
    {
        Account IBankOperation.account => account;

        Owner IBankOperation.owner => owner;

        float IBankOperation.amount => amount;

        Account account;

        Owner owner;

        float amount;


        public DepositOnAGivenAccount(Account account, Owner owner, float amount)
        {
            this.account = account;
            this.owner = owner;
            this.amount = amount;
        }

        public void Push()
        {
            using (var context = new bankEntities1())
            {
                Console.WriteLine(this.account.balance);
                var result = context.Accounts.SingleOrDefault(a => a.Id == this.account.Id);
                
                if (result != null)
                {
                    result.balance = result.balance + amount;
                    if (context.SaveChanges() > 0)
                    {
                        Console.WriteLine("Success!" + result.balance);
                    }
                }
            }
        }


    }
}
