namespace ProductivityTracker_DataAccess.DomainModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class UserLoginDetail
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [StringLength(200)]
        public string EmailId { get; set; }

        [Required]
        [StringLength(20)]
        public string Password { get; set; }

        public int UserType { get; set; }
    }
}
