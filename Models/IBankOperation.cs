using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bankdata.Models
{
    public interface IBankOperation
    {

        Account account { get; }
        Owner owner { get; }
        float amount { get; }

    }
}
