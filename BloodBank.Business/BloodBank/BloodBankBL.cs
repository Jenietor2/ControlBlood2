using BloodBank.Data.BloodBank;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace BloodBank.Business.BloodBank
{
    public class BloodBankBL
    {
        private readonly IConfiguration _configuration;
        private readonly BloodBankDAL bloodBank;

        public BloodBankBL(IConfiguration configuration)
        {
            _configuration = configuration;
            bloodBank = new BloodBankDAL(configuration);
        }

        public List<ControlBlood.Entity.BloodBank.BloodBank> GetBloodBanks()
        {
            return bloodBank.GetBloodBanks();
        }

        public bool InsertBloodBanks(ControlBlood.Entity.BloodBank.BloodBank prmBloodBank)
        {
            return bloodBank.InsertBloodBank(prmBloodBank);
        }
    }
}
