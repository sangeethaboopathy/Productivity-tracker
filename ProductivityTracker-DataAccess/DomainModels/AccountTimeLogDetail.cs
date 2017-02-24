namespace ProductivityTracker_DataAccess.DomainModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AccountTimeLogDetail
    {
        [Key]
        public int AccountTimeLogId { get; set; }

        public int AccountId { get; set; }

        public int UserId { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        [StringLength(200)]
        public string Comment { get; set; }
    }
}
