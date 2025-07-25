using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Entities.Concrete;

namespace TaskManager.DataAccess
{
    public class ContextDb : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            object value = optionsBuilder.UseSqlServer("Server=intranetdb.tirsan.com;Database=Stajyer;User Id=app_stajyer_user;Password=Asc16rr5asc!;TrustServerCertificate=true");
        }
        DbSet<User> Users { get; set; }
        DbSet<TaskItem> TaskItems {  get; set; }
    }
}
