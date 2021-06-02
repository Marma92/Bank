using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bankdata.Services
{
    public class RetrieveOperationsHistory
    {
        int accountId;

        public RetrieveOperationsHistory (int accountId)
        {
            this.accountId = accountId;
        }

        //public List<Account_History> Get()
        public void Get()
        {
            using (var context = new bankEntities1())
            {
                var operations = from bo in context.Account_History
                            where bo.Id == accountId
                            select bo;

                foreach (var operation in operations)
                {
                    Console.WriteLine("Operation n°" + operation.Id + " on Account n° " + operation.Id_account + " is a " + operation.operation_type + " of " + operation.amount + "€ at " + operation.operation_time + ", letting a balance of" + operation.balance + "€.");

                }
            }
        }

    }
}
