using ControlBlood.Data.Abstract;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace BloodBank.Data.BloodBank
{
    public class BloodBankDAL : AbstractCommonDAL
    {
        private readonly IConfiguration _configuration;
        string connectionString;

        public BloodBankDAL(IConfiguration configuration)
        {
            _configuration = configuration;

            connectionString = _configuration.GetSection("ConnectionStrings:DefaultConnection").Value;
        }
        public List<ControlBlood.Entity.BloodBank.BloodBank> GetBloodBanks()
        {
            try
            {
                List<ControlBlood.Entity.BloodBank.BloodBank> bloodBankList = new List<ControlBlood.Entity.BloodBank.BloodBank>();

                using (OracleConnection context = new OracleConnection(connectionString))
                {
                    context.Open();

                    using (OracleCommand command = new OracleCommand("STPGETBLOODBANK", context))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        OracleParameter output = command.Parameters.Add("bloodBank", OracleDbType.RefCursor);
                        output.Direction = System.Data.ParameterDirection.Output;

                        command.ExecuteNonQuery();

                        using (OracleDataReader reader = ((OracleRefCursor)output.Value).GetDataReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    ControlBlood.Entity.BloodBank.BloodBank bloodBank = new ControlBlood.Entity.BloodBank.BloodBank();

                                    bloodBank.ID = reader.GetInt32(0);
                                    bloodBank.Identification = reader.GetString(1);
                                    bloodBank.Departament = reader.GetString(2);
                                    bloodBank.City = reader.GetString(3);
                                    bloodBank.Address = reader.GetString(4);
                                    bloodBank.Phone = reader.GetString(5);
                                    bloodBank.CreationDate = reader.GetDateTime(6);
                                    bloodBank.IsActive = Convert.ToBoolean(reader.GetInt32(9));

                                    bloodBankList.Add(bloodBank);
                                }
                            }
                        }

                    }
                }

                return bloodBankList;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public bool InsertBloodBank(ControlBlood.Entity.BloodBank.BloodBank prmBloodBank)
        {
            try
            {
                using (OracleConnection context = new OracleConnection(connectionString))
                {
                    context.Open();

                    using (OracleCommand command = new OracleCommand("STPINSERTBLOODBANK", context))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.Add("PRM_NIT", OracleDbType.Varchar2).Value = prmBloodBank.Identification;
                        command.Parameters.Add("PRM_DEPARTAMENT", OracleDbType.Varchar2).Value = prmBloodBank.Departament;
                        command.Parameters.Add("PRM_CITY", OracleDbType.Varchar2).Value = prmBloodBank.City;
                        command.Parameters.Add("PRM_ADDRESS", OracleDbType.Varchar2).Value = prmBloodBank.Address;
                        command.Parameters.Add("PRM_PHONE", OracleDbType.Varchar2).Value = prmBloodBank.Phone;
                        command.Parameters.Add("PRM_CREATIONDATE", OracleDbType.Date).Value = DateTime.Now;
                        command.Parameters.Add("PRM_UPDATEDATE", OracleDbType.Date).Value = null;
                        command.Parameters.Add("PRM_DELETEDATE", OracleDbType.Date).Value = null;

                        command.ExecuteNonQuery();
                    }
                }

                        return true;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
