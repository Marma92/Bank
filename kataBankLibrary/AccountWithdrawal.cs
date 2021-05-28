using System;
using System.Collections.Generic;
using System.Text;

namespace kataBankLibrary
{
    class AccountWithdrawal : IBankOperation
    {
        public BankAccount account => throw new NotImplementedException();

        public float amount => throw new NotImplementedException();
    }
}
