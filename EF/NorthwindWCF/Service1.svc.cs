using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace NorthwindWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        private string _connectionString;

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public List<Customer> GetAllCustomers()
        {
            _connectionString = "Server =.\\; Database = Northwind; Trusted_Connection = True";

            var listCountryModel = new List<Customer>();
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand(@"SELECT
                                    [CustomerID]
                                  ,[CompanyName]
                                  ,[ContactName]
                                  ,[ContactTitle]
                                  ,[Address]
                                  ,[City]
                                  ,[Region]
                                  ,[PostalCode]
                                  ,[Country]
                                  ,[Phone]
                                  ,[Fax]
                              FROM[Northwind].[dbo].[Customers]", con);
                    con.Open();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            listCountryModel.Add(new Customer
                            {
                               CustomerId  = rdr[0].ToString(),
                                
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listCountryModel;
        }
    }
}
