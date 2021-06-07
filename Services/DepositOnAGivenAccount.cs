using bankdata.Events;
using bankdata.Models;
using bankdata.Specs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bankdata.Services
{
    public class DepositOnAGivenAccount : IBankOperation
    {
        Account IBankOperation.account => account;

        Owner IBankOperation.owner => owner;

        double IBankOperation.amount => amount;

        Account account;

        Owner owner;

        double amount;


        public DepositOnAGivenAccount(Account account, Owner owner, double amount)
        {
            AuthorizedAmountForAnOperationSpec aafaos = new AuthorizedAmountForAnOperationSpec();
            AuthorizedOperationAsAUserSpec aoaaus = new AuthorizedOperationAsAUserSpec(owner, account);

            if (aoaaus.isAuthorized())
            {
                if (aafaos.isSatisfiedBy(amount))
                {
                    this.account = account;
                    this.owner = owner;
                    this.amount = amount;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
            else
            {
                throw new NotYourAccountException();
            }

        }

        public void Push()
        {

            using (var context = new bankEntities1())
            {
                var result = context.Accounts.SingleOrDefault(a => a.Id == this.account.Id);   
                if (result != null)
                {
                    result.balance = result.balance + amount;
                    if (context.SaveChanges() > 0)
                    {
                        Account_History ah = new Account_History(this.account.Id, "deposit", DateTime.Now, this.amount,result.balance);
                        DomainEvent de = new DomainEvent(ah);
                        de.Push();
                        Console.WriteLine("Successfuly updated! ");
                    }
                }
            }
        }
    }
}
