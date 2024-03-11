using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using User_Domain;

namespace User_Infrastructure
{
    public class UserDbContext : DbContext
    {


        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Gender> GenderUsers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the one-to-one relationship
            modelBuilder.Entity<User>()
                .HasOne(u => u.CustoGenderMap)
                .WithOne().
                HasForeignKey<Gender>(key => key.ForeignKey);

        }


    }
}
