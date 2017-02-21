namespace ProductivityTracker_DataAccess.DomainModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MarketingAccountDetail
    {
        [Key]
        public int AccountId { get; set; }

        public int CustomAccountId { get; set; }

        [Required]
        [StringLength(100)]
        public string AccountName { get; set; }

        public DateTime StartDate { get; set; }

        [Required]
        [StringLength(20)]
        public string Status { get; set; }
    }
}
