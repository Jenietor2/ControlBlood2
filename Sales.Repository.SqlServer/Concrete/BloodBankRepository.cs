using BloodBank.Business.BloodBank;
using Microsoft.Extensions.Configuration;
using Sales.Repository.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Repository.Concrete
{
    public class BloodBankRepository : IBloodBankRepository
    {
        private readonly IConfiguration _configuration;
        private readonly BloodBankBL _bloodBankBL;

        public BloodBankRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _bloodBankBL = new BloodBankBL(_configuration);
        }

        public bool Create(ControlBlood.Entity.BloodBank.BloodBank bloodBank)
        {
            return _bloodBankBL.InsertBloodBanks(bloodBank);
        }

        public List<ControlBlood.Entity.BloodBank.BloodBank> GetAll()
        {
            try
            {
                return _bloodBankBL.GetBloodBanks();
            }
            catch (Exception ex)
            {
                throw;
            }
        }        
    }
}
