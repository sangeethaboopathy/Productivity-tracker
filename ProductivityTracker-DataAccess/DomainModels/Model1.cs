namespace ProductivityTracker_DataAccess.DomainModels
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<AccountTimeLogDetail> AccountTimeLogDetails { get; set; }
        public virtual DbSet<MarketingAccountDetail> MarketingAccountDetails { get; set; }
        public virtual DbSet<UserLoginDetail> UserLoginDetails { get; set; }
        public virtual DbSet<UserPersonalDetail> UserPersonalDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
