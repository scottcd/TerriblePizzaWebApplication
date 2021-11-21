using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TerriblePizzaWebApplication.Data {
    public class UserAccountDbContext : DbContext{
        public UserAccountDbContext(DbContextOptions<UserAccountDbContext> options)
                   : base(options) {
        }

        public DbSet<UserAccount> Account { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<UserAccount>().HasData(GetAccounts());
            base.OnModelCreating(modelBuilder);
        }

        private List<UserAccount> GetAccounts() {
            return new List<UserAccount>();
        }
    }
}
