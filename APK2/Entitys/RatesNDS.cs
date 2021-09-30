using APK2.Entitys.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APK2.Entitys
{
    public class RatesNDS: BaseEntity
    {
        public virtual Status Status { get; set; }
        public string Caption { get; set; }
        public decimal Rate { get; set; }

    }
}
