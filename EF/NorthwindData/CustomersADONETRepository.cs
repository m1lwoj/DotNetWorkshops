using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using NorthwindData.Models;
using System;
using System.Collections.Generic;

namespace NorthwindData
{
    public class CustomersADONETRepository : ICustomersRepository
    {
        private string _connectionString;

        public CustomersADONETRepository(IConfiguration iconfiguration)
        {
            _connectionString = iconfiguration.GetConnectionString("Default");
        }

        public List<Customer> GetAllCustomers()
        {
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
                                CustomerId = rdr[0].ToString(),
                                //CompanyName = rdr[1].ToString(),
                                //ContactName = rdr[2].ToString(),
                                //ContactTitle = rdr[3].ToString(),
                                //Address = rdr[4].ToString(),
                                //City = rdr[5].ToString(),
                                //Region = rdr[6].ToString(),
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

        public List<Customer> GetCustomersByName(string name)
        {
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
                              FROM[Northwind].[dbo].[Customers]
                              WHERE CompanyName LIKE @companyName", con);
                    cmd.Parameters.Add(new SqlParameter("companyName", $"%{name}%"));
                    con.Open();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            listCountryModel.Add(new Customer
                            {
                                CustomerId = rdr[0].ToString(),
                                CompanyName = rdr[1].ToString(),
                                ContactName = rdr[2].ToString(),
                                ContactTitle = rdr[3].ToString(),
                                Address = rdr[4].ToString(),
                                City = rdr[5].ToString(),
                                Region = rdr[6].ToString(),
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

        public void AddCustomer(Customer customer)
        {
            var listCountryModel = new List<Customer>();
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand(@"UPDATE...", con);
                    //cmd.Parameters.Add(new SqlParameter("companyName", $"%{name}%"));
                    con.Open();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            //listCountryModel.Add(new Customer
                            //{
                            //    CustomerId = rdr[0].ToString(),
                            //});
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateCustomer(string id, Customer customer)
        {
            var listCountryModel = new List<Customer>();
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand(@"UPDATE...", con);
                    //cmd.Parameters.Add(new SqlParameter("companyName", $"%{name}%"));
                    con.Open();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            //listCountryModel.Add(new Customer
                            //{
                            //    CustomerId = rdr[0].ToString(),
                            //});
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteCustomer(string id)
        {
            var listCountryModel = new List<Customer>();
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand(@"DELETE...", con);
                    //cmd.Parameters.Add(new SqlParameter("companyName", $"%{name}%"));
                    con.Open();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            //listCountryModel.Add(new Customer
                            //{
                            //    CustomerId = rdr[0].ToString(),
                            //});
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GetEmployeesNPlus1()
        {
            //N+1 Does not exists in ADO NET
        }
    }
}
