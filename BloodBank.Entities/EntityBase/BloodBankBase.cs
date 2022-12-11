using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Entity.EntityBase
{
    public class BloodBankBase
    {
        public int ID { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime DeleteDate { get; set; }
        public bool IsActive { get; set; }
    }
}
