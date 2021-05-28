using System;
using System.Collections.Generic;
using System.Text;

namespace kataBankLibrary
{
    interface IBankOperation
    {
        BankAccount account { get; }
        float amount { get;  }


    }
}
