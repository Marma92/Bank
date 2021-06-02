using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bankdata.Specs
{
    class AuthorizedOperationAsAUserSpec
    {
        //Ici une méthode qui autorise ou non un utilisateur à effectuer une opération sur un compte donné. 
        //Prend un objet owner et un objet account
        Owner owner;

        Account account;

        public AuthorizedOperationAsAUserSpec(Owner owner, Account account)
        {
            this.owner = owner;
            this.account = account;
        }

        public bool isAuthorized()
        {
            if (this.owner.Id == this.account.Id_owner)
            {
                Console.WriteLine("DEBUG : Owner ID:"+ this.owner.Id +" Account Id_Owner: " + account.Id_owner);
                return true;
            }

            return false;

        }
    }
}
