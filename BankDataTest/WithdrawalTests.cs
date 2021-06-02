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
    class WithdrawalTests
    {
        [Test]
        public void DoesWithdrawalAffectsTheBalanceCorrectly(
        [Values(2.0, 300, 10)] double amount,
        [Values(1, 2)] int accountId)
        {
            Owner owner = new Owner();
            Account account = new Account();
            double previousBalance;

            using (var context = new bankEntities1())
            {
                var query = from bo in context.Accounts
                            where bo.Id == accountId
                            select bo;

                account = query.FirstOrDefault<Account>();
                previousBalance = account.balance;
                Console.WriteLine("Account ID:  " + account.Id + "Balance: " + account.balance);
            }

            WithdrawalOnAGivenAccount withdrawal = new WithdrawalOnAGivenAccount(account, owner, amount);
            withdrawal.Push();

            //retrieving the new balance and comparing it to expected.
            using (var context = new bankEntities1())
            {
                account = new Account();
                var query = from bo in context.Accounts
                            where bo.Id == accountId
                            select bo;

                account = query.FirstOrDefault<Account>();
                Console.WriteLine("Account ID: " + account.Id + "Previous: " + previousBalance + " New Balance: " + account.balance);
                Assert.AreEqual((previousBalance - amount), account.balance);
            }
        }

        //Test if an exception is thrown when we try to withdraw a negative amount.
        [Test]
        public void IsNegativeWithdrawalForbidden(
           [Values(-2.0, -300, -10)] double amount,
           [Values(1, 2)] int accountId)
        {
            //Arrange
            Owner owner = new Owner();
            Account account = new Account();
            double previousBalance;


            //Act
            void CheckFunction()
            {
                using (var context = new bankEntities1())
                {
                    var query = from bo in context.Accounts
                                where bo.Id == accountId
                                select bo;

                    account = query.FirstOrDefault<Account>();
                    previousBalance = account.balance;
                    Console.WriteLine("Account ID:  " + account.Id + "Balance: " + account.balance);
                }
                WithdrawalOnAGivenAccount withdrawal = new WithdrawalOnAGivenAccount(account, owner, amount);
            }

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => CheckFunction());
        }


        //TODO: Test if an owner can withdraw more than the account's balance

    }
}
