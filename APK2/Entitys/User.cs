using APK2.Entitys.Base;


namespace APK2.Entitys
{
   public class User:BaseEntity
    {
        public virtual Status Status { get; set; }
        public string NameUser { get; set; }
        public string LoginUser { get; set; }

    }
}
