using APK2.Entitys.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APK2.Entitys
{
   public class Group : BaseEntity
    {
        public Status Status { get; set; }
        public string NameGroup { get; set; }
        public string TableGroup { get; set; }

    }
}
