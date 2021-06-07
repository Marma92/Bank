using bankdata;
using bankdata.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDataTest
{
    [TestFixture]
    class HistoryTests
    {
               
        //Does an operation register on our history ?
        [Test]
        public void DoesDepositRegisterInTheHistoryCorrectly(
           [Values(2.0, 300, 10)] double amount,
           [Values(1, 2)] int accountId)
        {
            
            //Arrange
            Owner owner = new Owner();
            Account account = new Account();

            using (var context = new bankEntities1())
            {
                var query = from bo in context.Accounts
                            where bo.Id == accountId
                            select bo;

                account = query.FirstOrDefault<Account>();
                
            }
            owner.Id = account.Id_owner;

            //Act
            Console.WriteLine("Account ID:  " + account.Id + "Balance: " + account.balance);
            DepositOnAGivenAccount deposit = new DepositOnAGivenAccount(account, owner, amount);
            deposit.Push();

            //retrieving the new balance and comparing it to expected.
            using (var context = new bankEntities1())
            {
                Account_History account_history ;
                var query = from ah in context.Account_History
                            where ah.Id_account == accountId && ah.amount == amount
                            select ah;

                account_history = query.FirstOrDefault<Account_History>();
                Account_History expectedHistory = new Account_History (account.Id, "deposit", DateTime.Now, amount, account.balance + amount );
                account_history.operation_type = account_history.operation_type.Trim();
                //Assert
                Assert.AreEqual(account_history.ToString(), expectedHistory.ToString());
            }
        }

    }
}
