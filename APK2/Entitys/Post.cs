using APK2.Entitys.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APK2.Entitys
{
    public class Post : BaseEntity
    {
        public Guid Guid { get; set; }

        public virtual Status Status { get; set; }
        public string NamePost { get; set; }

    }
}
