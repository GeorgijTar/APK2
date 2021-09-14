using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APK2.Data
{
    class Connection
    {
        private readonly DataContext _db;

        public Connection(DataContext db) { _db = db; }


        public async Task InitializeAsync()
        {
            await _db.Database.MigrateAsync().ConfigureAwait(false);
        }

    }
}
