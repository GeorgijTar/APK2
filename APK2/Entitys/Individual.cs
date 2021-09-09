using APK2.Entitys.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APK2.Entitys
{
    public class Individual : BaseEntity
    {
        
        public Guid Guid { get; set; }
        public Status Status { get; set; }
        public Group Group { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Patpatronymic { get; set; }
        public string Inn { get; set; }
        public string Snils { get; set; }
        
        public DateTime Birthdate { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public ICollection <DocumentsIndividual> Documents { get; set; }
        public TimeSpan TimeSpan { get; set; }
    }
}
