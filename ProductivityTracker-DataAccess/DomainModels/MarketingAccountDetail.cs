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

        [Required]
        [StringLength(50)]
        public string CustomAccountId { get; set; }

        [Required]
        [StringLength(100)]
        public string AccountName { get; set; }

        public DateTime StartDate { get; set; }

        [Required]
        [StringLength(20)]
        public string Status { get; set; }

        public DateTime CreatedOn { get; set; }

        public int CreatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public int? UpdatedBy { get; set; }

        public int StatusInt { get; set; }
    }
}
