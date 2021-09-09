using APK2.Data;
using APK2.Entitys.Base;
using APK2.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APK2.Service
{
    public class DbRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly DataContext db;
        private DbSet<T> Set { get; }

        public DbRepository(DataContext db)
        {
            this.db = db;
            Set = db.Set<T>();
        }

        public int Add(T item)
        {
            db.Entry(item).State = EntityState.Added;
            db.SaveChanges();
            return item.Id;
        }

        public IEnumerable<T> GetAll() => Set;

        public T GetId(int id) => Set.Find(id);
        

        public bool Remove(int id)
        {
            var item = GetId(id);
            if (item is null) return false;
            db.Entry(item).State = EntityState.Deleted;
            db.SaveChanges();
            return true;
        }

        public void Update(T item)
        {
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
