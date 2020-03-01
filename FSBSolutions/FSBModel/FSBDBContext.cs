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

        public DbSet<Location> Locations { get; set; }

        public DbSet<Machine> Machines { get; set; }

        public DbSet<Module> Modules { get; set; }
        public DbSet<Component> Components { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Verlust> Verlusts { get; set; }
        public DbSet<Verlustart> Verlustarts { get; set; }        
        public DbSet<WasteType> WasteTypes { get; set; }
        public DbSet<Reason> Reasons { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<WasteDetail> WasteDetails { get; set; }
        public DbSet<MasterDataInfo> MasterDataInfos { get; set; }

        public DbSet<OrderInfo> OrderInfos { get; set; }
        public DbSet<OrderProducedVolume> OrderProducedVolumes { get; set; }

        public DbSet<AspNetRoles> AspNetRoles { get; set; }

        public DbSet<Customer> Customers { get; set; }

    }
}
