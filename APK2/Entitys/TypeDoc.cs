using APK2.Entitys.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APK2.Entitys
{
  public  class TypeDoc : BaseEntity
    {
        public Status Status { get; set; }
        public string NameType { get; set; }
        public string TableType { get; set; }
    }
}
