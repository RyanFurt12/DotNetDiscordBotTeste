using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetDiscordBotTeste.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNetDiscordBotTeste.Data
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions options) : base(options){}

        public DbSet<Server> Servers { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Data/UserData.db");
        }
    }
}