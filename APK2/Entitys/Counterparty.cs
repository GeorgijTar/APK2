using APK2.Entitys.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APK2.Entitys
{
    public class Counterparty : BaseEntity
    {

        public Status Status { get; set; }

        public Guid Guid { get; set; }

        [Required(ErrorMessage = "Наименование обязательное поле")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Платежное наименование обязательное поле")]
        public string PayName { get; set; }

        [Required (ErrorMessage = "ИНН обязательное поле"), StringLength(12, MinimumLength = 10, ErrorMessage = "Недопустимый ИНН")]
        public string INN { get; set; }

        [StringLength(9, MinimumLength = 0, ErrorMessage = "Недопустимый КПП")]
        public string KPP { get; set; }

        [StringLength(15, MinimumLength = 13, ErrorMessage = @"Недопустимый ОГРН/ОГРНИП")]
        public string OGRN { get; set; }

        [StringLength(10, MinimumLength = 8, ErrorMessage = "Недопустимый ОКПО")]
        public string OKPO { get; set; }

        [Phone(ErrorMessage = "Не верный формат телефона")]
        public string PhoneNumber { get; set; }

        [EmailAddress(ErrorMessage = "Не верный формат адреса электронной почты")]
        public string Email { get; set; }

        public DateTime RegistrationDate { get; set; } //Дата регистрации организации

        public string Address { get; set; } //Адрес для документов

        public Account Account { get; set; }

        public TimeSpan TimeSpan { get; set; }
    }
}
