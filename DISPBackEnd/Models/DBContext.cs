using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
//@"Server=(localdb)\MSSQLLocalDB;Database=Blogging;Integrated Security=True"
namespace DISPBackEnd.Models
{
    public class DBContext : DbContext
    {
        
        public DbSet<HaandVaerker> HaandVaerkers { get; set; }
        public DbSet<Vaerktoej> Vaerktoejs { get; set; }
        public DbSet<Vaerktoejskasse> Vaerktoejskasses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=35.228.29.237;Database=Gr11DBOpg1 ;User ID=SA;Password=F21swtdisp!!;MultipleActiveResultSets=true");
        }
    }
}

