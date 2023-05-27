using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using AiderHub.Models;

namespace AiderHub.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base(nameOrConnectionString: "Myconnection")
        {

        }

        public virtual DbSet<Evento> Eventos { get; set; }
    }
}