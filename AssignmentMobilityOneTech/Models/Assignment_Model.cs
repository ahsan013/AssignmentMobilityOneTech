using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace AssignmentMobilityOneTech.Models
{
    public partial class Assignment_Model : DbContext
    {
        public Assignment_Model()
            : base("name=Assignment_Model")
        {
        }

        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
