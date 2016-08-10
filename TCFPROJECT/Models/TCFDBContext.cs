using System.IO;
using System.Web;

namespace TCFPROJECT.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Collections.Generic;

    public partial class TCFDBContext : IdentityDbContext<User>
    {
        public TCFDBContext() : base("TCFDBContext")
        {
           
        }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<QuestionClaim> QuestionClaims { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<City> Citys { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<Cluster> Clusters { get; set; }
        public DbSet<University> Universitys { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Session> Sessions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
        }

    }
}
