using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entity
{
    public class TaskEntity
    {
        public int taskID { get; set; }

        public int OfferID { get; set; }

        public int UserID { get; set; }

        public int SponsorID { get; set; }
        public string MoneyQuantity { get; set; }
        public string Month { get; set; }

        public int SponsorTypeID { get; set; }
    }
}
