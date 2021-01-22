namespace AssignmentMobilityOneTech.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Users
    {
        [Key]
        public int Id { get; set; }

        [StringLength(32)]
        public string Name { get; set; }

        [StringLength(16)]
        public string PhoneNumber { get; set; }

        [StringLength(38)]
        public string EmailAddress { get; set; }

        [StringLength(42)]
        public string Password { get; set; }

        public DateTime LastLogin { get; set; }

        public DateTime CreateDate { get; set; }

        public bool Suspended { get; set; }
    }
}
