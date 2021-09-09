using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APK2.Entitys.Base;

namespace APK2.Interfaces
{
   public interface IRepository<T> where T : BaseEntity
    {
        public IEnumerable<T> GetAll();

        T GetId(int id);

        int Add(T item);

        void Update(T item);

        bool Remove(int id);
    }
}
