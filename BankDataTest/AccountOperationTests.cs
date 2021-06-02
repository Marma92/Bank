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
    public class AccountOperationTests
    {

        /*US 1:
        In order to save money
        As a bank client
        I want to make a deposit in my account*/

        //Tester que l'ajout est bien effectué
        [Test]
        public void DepositTest(
           [Values(2.0, 300, 10)] double amount,
           [Values(1)] int accountId)
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
             
            DepositOnAGivenAccount deposit = new DepositOnAGivenAccount(account, owner, amount);
            deposit.Push();

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

        //Tester que si l'ajout est un chiffre négatif, une exception est levée.
        /*[Test]
        public void NegativeDepositIsForbidden
        {
            Assert.Pass();
        }
        */

        // Pour la donnée : Intégration d'une bdd SQL Compact
        // La base est détruite et reconstruite à chaque build
        // Appliquer les tests de changement des valeur en base de données.

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
