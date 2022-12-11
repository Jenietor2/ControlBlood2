using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Repository.Contract
{
    public interface IBloodBankRepository
    {
        List<ControlBlood.Entity.BloodBank.BloodBank> GetAll();
        bool Create(ControlBlood.Entity.BloodBank.BloodBank bloodBank);
    }
}
