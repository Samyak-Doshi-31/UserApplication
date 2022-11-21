using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using UserApplication.Models;

namespace UserApplication.Context
{
    public class UserApplicationDbContext : DbContext
    {
        public UserApplicationDbContext(DbContextOptions<UserApplicationDbContext> Context) : base(Context)
        {

        }
        //create a table
        public DbSet<Register> Register { get; set; }
        public DbSet<Friend> Friend { get; set; }

    }
}
