namespace ProductivityTracker_DataAccess.DomainModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ProjectDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProjectDetail()
        {
            MarketingAccountDetails = new HashSet<MarketingAccountDetail>();
        }

        public int Id { get; set; }

        [StringLength(500)]
        public string ProjectName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MarketingAccountDetail> MarketingAccountDetails { get; set; }
    }
}
