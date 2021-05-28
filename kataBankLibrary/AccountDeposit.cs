using System;
using System.Collections.Generic;
using System.Text;

namespace kataBankLibrary
{
    public class AccountDeposit : IBankOperation
    {

        public AccountDeposit(float amount, BankAccount account)
        {
            this.amount = amount;
            this.account = account;
        }
        public BankAccount account { get; }
        public float amount { get; }


    }
}
