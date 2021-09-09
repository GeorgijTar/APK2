using APK2.Entitys.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APK2.Entitys
{
    public class DocumentsIndividual: BaseEntity
    {
        public Guid Guid { get; set; }
        public Status Status { get; set; }
        public TypeDoc TypeDoc { get; set; }
        public string Series { get; set; }
        public string Number { get; set; }
        public DateTime DateIssue { get; set; }
        public string WhoIssued { get; set; }
        public string DepartmentCode { get; set; }
        public DateTime DateOffAction { get; set; }
        public bool DocUl { get; set; }
        public TimeSpan TimeSpan { get; set; }
    }
}
