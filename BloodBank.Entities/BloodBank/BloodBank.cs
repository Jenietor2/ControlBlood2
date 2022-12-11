using Sales.Entity.EntityBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControlBlood.Entity.BloodBank
{
    public class BloodBank : BloodBankBase
    {        
        public string Identification { get; set; }
        public string Departament { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}
