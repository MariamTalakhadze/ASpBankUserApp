namespace ASpBankUserApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    [Table("Task")]
    public partial class Task
    {
        public int taskID { get; set; }

        public int OfferID { get; set; }

        public int UserID { get; set; }

        public int SponsorID { get; set; }

        [Required]
        [StringLength(50)]
        public string MoneyQuantity { get; set; }

        [Required]
        [StringLength(20)]
        public string Month { get; set; }

        public int SponsorTypeID { get; set; }

        public virtual Offer Offer { get; set; }

        public virtual SponsorType SponsorType { get; set; }

        public virtual User User { get; set; }

        public virtual User User1 { get; set; }
    }
}
