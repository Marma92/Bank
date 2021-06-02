using bankdata.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bankdata
{
    class Program
    {
        static void Main(string[] args)
        {
           /* Owner owner = new Owner();
            Account account = new Account();
            using (var context = new bankEntities1())
            {
                var query = from bo in context.Accounts
                            where bo.Id == 3
                            select bo;

                account = query.FirstOrDefault<Account>();
                Console.WriteLine(account.Id + " " + account.balance);
            }

            Console.WriteLine("Update");
            DepositOnAGivenAccount deposit = new DepositOnAGivenAccount(account , owner, 1000);
            deposit.Push();*/
            //
            //
            //Console.WriteLine(account.Id + " " + account.balance);
            Console.ReadKey();

        }
    }
}
