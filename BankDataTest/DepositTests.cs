using bankdata;
using bankdata.Services;
using bankdata.Specs;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDataTest
{
    [TestFixture]
    public class DepositTests
    {

        /*US 1:
        In order to save money
        As a bank client
        I want to make a deposit in my account*/

        //Test if the deposit have been well done on the client account.
        [Test]
        public void DoesDepositAffectsTheBalanceCorrectly(
           [Values(2.0, 300, 10)] double amount,
           [Values(1,2)] int accountId)
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
                Console.WriteLine("Account ID:  "+account.Id + "Balance: " +account.balance);
            }
            owner.Id = account.Id_owner; 

            DepositOnAGivenAccount deposit = new DepositOnAGivenAccount(account, owner, amount);
            deposit.Push();

            //retrieving the new balance and comparing it to expected.
            using (var context = new bankEntities1())
            {
                account = new Account();
                var query = from bo in context.Accounts
                            where bo.Id == accountId
                            select bo;

                account = query.FirstOrDefault<Account>();
                Console.WriteLine("Account ID: " + account.Id + "Previous: " + previousBalance + " New Balance: " + account.balance);
                Assert.AreEqual( (previousBalance + amount) ,account.balance);
            }
        }

        //Test if an exception is thrown when we try to deposit a negative amount.
        [Test]
        public void IsNegativeDepositForbidden(
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
                owner.Id = account.Id_owner;
                DepositOnAGivenAccount deposit = new DepositOnAGivenAccount(account, owner, amount);
            }
 
            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => CheckFunction());
        }
        
        //Test if the user trying to deposit money can do it on an account it does not own
        [Test]
        public void IsTheAccountProtectedFromAStranger(
            [Values(3, 1, 2)] int accountId,
            [Values(1, 2, 3)] int UserId)
        {
            Owner owner = new Owner();
            Account account = new Account();
            double previousBalance;
            owner.Id = UserId;

            using (var context = new bankEntities1())
            {
                var query = from bo in context.Accounts
                            where bo.Id == accountId
                            select bo;

                account = query.FirstOrDefault<Account>();
                previousBalance = account.balance;
                Console.WriteLine("Account ID:  " + account.Id + "Balance: " + account.balance);
            }

            
            Assert.Throws<NotYourAccountException>(() =>  new DepositOnAGivenAccount(account, owner, 100));

        }

        /*US 2:
        In order to retrieve some or all of my savings
        As a bank client
        I want to make a withdrawal from my account*/



        /*US 3:
         In order to check my operations
         As a bank client
         I want to see the history(operation, date, amount, balance) of my operations*/
    }
}
