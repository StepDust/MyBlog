using Interface.Factory;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Factory
{
    public class DBSessionFactory : IDBSessionFactory
    {
        public DbContext DBContext { get; private set; }
        
        public DBSessionFactory(DbContext dbContext)
        {
            this.DBContext = dbContext;
        }

    }
}
