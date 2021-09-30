using APK2.Entitys.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APK2.Entitys
{
   public class Employee:BaseEntity
    {
        public Guid Guid { get; set; }
        public virtual Status Status { get; set; }
        public int TabNamber { get; set; }
        public virtual Post Post { get; set; }
        public DateTime DateAdmission { get; set; } // Дата приема
        public DateTime DateDismissal { get; set; } // Дата увольнения

    }
}
