using APK2.Entitys.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APK2.Entitys
{
   public class Invoce:BaseEntity
    {
        public Guid Guid { get; set; }
        public virtual Status Status { get; set; }         
        public int RegistrNumber { get; set; }
        public DateTime RegistrDate { get; set; }
        public string NumberInvoce { get; set; }
        public DateTime DateInvoce { get; set; }
        public virtual Counterparty Counterparty { get; set; }
        public string NoteInvoce { get; set; }
        public decimal Amount { get; set; }
        public virtual RatesNDS RatesNDS { get; set; }
        public decimal AmountNDS { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime DateTimeCreat { get; set; }
        public virtual User UserCreat { get; set; }
        public DateTime LastChange { get; set; }

    }
}
