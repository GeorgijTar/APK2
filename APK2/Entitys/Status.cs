using APK2.Entitys.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APK2.Entitys
{
  public  class Status : BaseEntity
    {
        [Required]
        public string Name { get; set; }

    }
}
