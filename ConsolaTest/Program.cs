using Oracle.ManagedDataAccess.Client;
using Sales.Data.Product;
using System;
using System.Data.OracleClient;

namespace ConsolaTest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (OracleConnection context = new OracleConnection("DATA SOURCE = localhost:1521/xe ; PASSWORD = 123; User ID = adminBloodBank; "))
                {
                    context.Open();
                    Console.WriteLine("Conectado");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Ocurrio el siguiente error {ex.Message}");
            }
            
        }        
    }
}
