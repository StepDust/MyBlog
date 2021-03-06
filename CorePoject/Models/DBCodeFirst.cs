﻿using Microsoft.EntityFrameworkCore;
using Models.DataTable;

namespace Models
{
    public class DBCodeFirst : DbContext
    {
        public DBCodeFirst(DbContextOptions options)
            : base(options)
        {
        }

        override protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        #region 数据表

        public DbSet<DT_User> DT_User { get; set; }

        #endregion

    }
}
