using APK2.Entitys.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APK2.Entitys
{
   public class Account: BaseEntity
    {
        public Guid Guid { get; set; }

        public Status Status { get; set; }

        [Required(ErrorMessage = "Наименование банка обязательно для заполнения")]
        public string NameBank { get; set; }

        [Required(ErrorMessage = "БИК банка обязательно для заполнения"), StringLength(9, MinimumLength = 9, ErrorMessage = "Недопустимый БИК")]
        public string BIK { get; set; }

        [Required(ErrorMessage = "Кор. счет обязательно для заполнения"), StringLength(20, MinimumLength = 20, ErrorMessage = @"Недопустимый Кор/счет")]
        public string KorShet { get; set; }

        [Required(ErrorMessage = "Расчетный счет обязательно для заполнения"), StringLength(20, MinimumLength = 20, ErrorMessage = @"Недопустимый Р/счет")]
        public string RsShet { get; set; }

        Counterparty Counterparty { get; set; }

    }
}
