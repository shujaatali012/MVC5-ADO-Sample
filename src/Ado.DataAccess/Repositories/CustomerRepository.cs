/// <summary>
/// Customer repository implementation
/// </summary>

namespace Ado.DataAccess.Repositories
{
    #region import namespaces

    using System.Collections.Generic;
    using Repositories.Interfaces;
    using Ado.DataAccess.Infrastructure.Database;
    using Entities;
    using System.Data.SqlClient;
    using System.Data;
    using System;


    #endregion

    public class CustomerRepository : ICustomerRepository
    {
        #region properties

        private readonly IDbFactory _dbFactory;

        #endregion

        #region constructor(s)

        public CustomerRepository(IDbFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }

        #endregion

        public string Add(Customer customer)
        {
            string result = string.Empty;

            try
            {
                using (SqlConnection connection = _dbFactory.EstablishedConnection())
                {
                    SqlCommand cmd = new SqlCommand("Sp_InsertUpdateDelete_Customer", connection);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Id", 0);
                    cmd.Parameters.AddWithValue("@Name", customer.Name);
                    cmd.Parameters.AddWithValue("@Address", customer.Address);
                    cmd.Parameters.AddWithValue("@Mobile", customer.Mobile);
                    cmd.Parameters.AddWithValue("@BirthDate", customer.BirthDate);
                    cmd.Parameters.AddWithValue("@Email", customer.Email);
                    cmd.Parameters.AddWithValue("@Query", 1);

                    result = cmd.ExecuteScalar().ToString();
                }
            }
            catch (SqlException ex)
            {
                result = ex.Message.ToString();
            }

            return result;
        }

        public string Update(Customer customer)
        {
            string result = string.Empty;

            try
            {
                using (SqlConnection connection = _dbFactory.EstablishedConnection())
                {
                    SqlCommand cmd = new SqlCommand("Sp_InsertUpdateDelete_Customer", connection);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Id", customer.Id);
                    cmd.Parameters.AddWithValue("@Name", customer.Name);
                    cmd.Parameters.AddWithValue("@Address", customer.Address);
                    cmd.Parameters.AddWithValue("@Mobile", customer.Mobile);
                    cmd.Parameters.AddWithValue("@BirthDate", customer.BirthDate);
                    cmd.Parameters.AddWithValue("@Email", customer.Email);
                    cmd.Parameters.AddWithValue("@Query", 2);

                    result = cmd.ExecuteScalar().ToString();
                }
            }
            catch (SqlException ex)
            {
                result = ex.Message.ToString();
            }

            return result;
        }

        public string Delete(int id)
        {
            string result = string.Empty;

            try
            {
                using (SqlConnection connection = _dbFactory.EstablishedConnection())
                {
                    SqlCommand cmd = new SqlCommand("Sp_InsertUpdateDelete_Customer", connection);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@Name", null);
                    cmd.Parameters.AddWithValue("@Address", null);
                    cmd.Parameters.AddWithValue("@Mobile", null);
                    cmd.Parameters.AddWithValue("@BirthDate", null);
                    cmd.Parameters.AddWithValue("@Email", null);
                    cmd.Parameters.AddWithValue("@Query", 3);

                    result = cmd.ExecuteScalar().ToString();
                }
            }
            catch (SqlException ex)
            {
                result = ex.Message.ToString();
            }

            return result;
        }

        public List<Customer> GetAll()
        {
            try
            {
                DataSet dataSet = null;
                List<Customer> customerList = null;

                using (SqlConnection connection = _dbFactory.EstablishedConnection())
                {
                    SqlCommand cmd = new SqlCommand("Sp_InsertUpdateDelete_Customer", connection);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Id", null);
                    cmd.Parameters.AddWithValue("@Name", null);
                    cmd.Parameters.AddWithValue("@Address", null);
                    cmd.Parameters.AddWithValue("@Mobile", null);
                    cmd.Parameters.AddWithValue("@BirthDate", null);
                    cmd.Parameters.AddWithValue("@Email", null);
                    cmd.Parameters.AddWithValue("@Query", 4);

                    SqlDataAdapter dataAdapter = new SqlDataAdapter();

                    dataAdapter.SelectCommand = cmd;
                    dataSet = new DataSet();
                    dataAdapter.Fill(dataSet);

                    customerList = new List<Customer>();

                    for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                    {
                        Customer customer = new Customer();

                        customer.Id = Convert.ToInt32(dataSet.Tables[0].Rows[i]["Id"].ToString());
                        customer.Name = dataSet.Tables[0].Rows[i]["Name"].ToString();
                        customer.Address = dataSet.Tables[0].Rows[i]["Address"].ToString();
                        customer.Mobile = dataSet.Tables[0].Rows[i]["Mobile"].ToString();
                        customer.Email = dataSet.Tables[0].Rows[i]["Email"].ToString();
                        customer.BirthDate = Convert.ToDateTime(dataSet.Tables[0].Rows[i]["BirthDate"].ToString());

                        customerList.Add(customer);
                    }

                    return customerList;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public Customer GetById(int id)
        {
            try
            {
                DataSet dataSet = null;
                Customer customer = null;

                using (SqlConnection connection = _dbFactory.EstablishedConnection())
                {
                    SqlCommand cmd = new SqlCommand("Sp_InsertUpdateDelete_Customer", connection);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@Name", null);
                    cmd.Parameters.AddWithValue("@Address", null);
                    cmd.Parameters.AddWithValue("@Mobile", null);
                    cmd.Parameters.AddWithValue("@BirthDate", null);
                    cmd.Parameters.AddWithValue("@Email", null);
                    cmd.Parameters.AddWithValue("@Query", 5);

                    SqlDataAdapter dataAdapter = new SqlDataAdapter();

                    dataAdapter.SelectCommand = cmd;
                    dataSet = new DataSet();
                    dataAdapter.Fill(dataSet);
                    
                    for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                    {
                        customer = new Customer();

                        customer.Id = Convert.ToInt32(dataSet.Tables[0].Rows[i]["Id"].ToString());
                        customer.Name = dataSet.Tables[0].Rows[i]["Name"].ToString();
                        customer.Address = dataSet.Tables[0].Rows[i]["Address"].ToString();
                        customer.Mobile = dataSet.Tables[0].Rows[i]["Mobile"].ToString();
                        customer.Email = dataSet.Tables[0].Rows[i]["Email"].ToString();
                        customer.BirthDate = Convert.ToDateTime(dataSet.Tables[0].Rows[i]["BirthDate"].ToString());
                    }

                    return customer;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
