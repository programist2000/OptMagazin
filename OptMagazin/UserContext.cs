using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OptMagazin.Models;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace OptMagazin
{

    public class UserContext : DbContext
    {

        public UserContext() : base("DbConnection") { }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

    }
}