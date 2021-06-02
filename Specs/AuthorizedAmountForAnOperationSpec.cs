using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bankdata.Specs
{
    class AuthorizedAmountForAnOperationSpec
    {
        public bool isSatisfiedBy(double amount){
            if ( amount <= 0)
            {
                return false;
            }
            
            return true;
        }   

    }
}
