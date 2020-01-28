using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSBModel
{
    public class FSBDBContext : DbContext
    {

        public FSBDBContext()
            : base("name=FSBDBContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
        public DbSet<Country> Countries { get; set; }

        public DbSet<Company> Companies { get; set; }

        public DbSet<Plant> Plants { get; set; }

        public DbSet<Shift> Shifts { get; set; }

        public DbSet<Line> Lines { get; set; }

        public DbSet<UserType> UserTypes { get; set; }

        public DbSet<User> Users { get; set; }
    }
}
