//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace bankdata
{
    using System;
    using System.Collections.Generic;
    
    public partial class Account_History
    {
        public int Id { get; set; }
        public int Id_account { get; set; }
        public string operation_type { get; set; }
        public System.DateTime operation_time { get; set; }
        public double amount { get; set; }
        public double balance { get; set; }

        public Account_History(int Id_account, string operation_type, System.DateTime operation_time, double amount, double balance)
        {
            this.Id_account = Id_account;
            this.operation_type = operation_type;
            this.operation_time = operation_time;
            this.amount = amount;
            this.balance = balance;
        }
    }
}
