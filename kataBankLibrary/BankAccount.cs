using System;

namespace kataBankLibrary
{
    public class BankAccount
    {
        private BankCustomer owner;
        public readonly float balance;
        public readonly int id;

        public BankAccount(BankCustomer owner)
        {
            this.owner = owner;
            this.balance = 0;
        }
    }
}
