using kataBankLibrary;
using NUnit.Framework;
using System;

namespace kataBankTestLibrary
{
    [TestFixture]
    public class BankAccountTests
    {

        /*US 1:
        In order to save money
        As a bank client
        I want to make a deposit in my account*/

        //Tester que l'ajout est bien effectué
        [Test]
        public void DepositTest(
           [Values (2.0, 300.10)]float amount )
        {
            BankCustomer owner = new BankCustomer("Amram ELBAZ");
            BankAccount account = new BankAccount(owner);
            float previousAmount = account.balance;
            AccountDeposit deposit = new AccountDeposit(amount, account);
            Assert.AreEqual(account.balance, previousAmount + deposit.amount);
            
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
