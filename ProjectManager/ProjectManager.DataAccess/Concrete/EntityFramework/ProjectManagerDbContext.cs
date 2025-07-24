using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Entities.Concrete;

namespace ProjectManager.DataAccess.Concrete.EntityFramework
{
    public class ProjectManagerDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=intranetdb.tirsan.com;Database=Stajyer;User Id=app_stajyer_user;Password=Asc16rr5asc!;TrustServerCertificate=true");
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Board> Boards { get; set; }
    }
}
