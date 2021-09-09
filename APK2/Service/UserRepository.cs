using APK2.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APK2.Service;

namespace APK2.Service
{
    public class UserRepository
    {

        public List<User> CarUser { get; set; }
  

        public IEnumerable<User> GetAll()=>CarUser;

        public void Add(User user)
        {
            CarUser.Add(user);
        }

        public void Remove(User user)
        {
            CarUser.Remove(user);
        }

    }
}
