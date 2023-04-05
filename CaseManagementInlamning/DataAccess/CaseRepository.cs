using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using CaseManagementInlamning.Models;

namespace CaseManagementInlamning.DataAccess
{
    internal class CaseRepository
    {
        private readonly string _CaseManagementDBConnectionString;

        public CaseRepository(string caseManagementDBConnectionString)
        {
            _CaseManagementDBConnectionString = caseManagementDBConnectionString;
        }

        public List<Case> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(_CaseManagementDBConnectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Cases", connection);
                SqlDataReader reader = cmd.ExecuteReader();
                List<Case> cases = new List<Case>();
                while (reader.Read())
                {
                    cases.Add(new Case
                    {
                        CaseId = Convert.ToInt32(reader["CaseId"]),
                        CustomerFirstName = reader["CustomerFirstName"].ToString(),
                        CustomerLastName = reader["CustomerLastName"].ToString(),
                        CustomerEmail = reader["CustomerEmail"].ToString(),
                        CustomerPhone = reader["CustomerPhone"].ToString(),
                        Description = reader["Description"].ToString(),
                        CreatedAt = Convert.ToDateTime(reader["CreatedAt"]),
                        Status = (CaseStatus)Enum.Parse(typeof(CaseStatus), reader["Status"].ToString())
                    });
                }
                return cases;
            }
        }

        public Case GetById(int caseId)
        {
            using (SqlConnection connection = new SqlConnection(_CaseManagementDBConnectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Cases WHERE CaseId = @caseId", connection);
                cmd.Parameters.AddWithValue("@caseId", caseId);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new Case
                    {
                        CaseId = Convert.ToInt32(reader["CaseId"]),
                        CustomerFirstName = reader["CustomerFirstName"].ToString(),
                        CustomerLastName = reader["CustomerLastName"].ToString(),
                        CustomerEmail = reader["CustomerEmail"].ToString(),
                        CustomerPhone = reader["CustomerPhone"].ToString(),
                        Description = reader["Description"].ToString(),
                        CreatedAt = Convert.ToDateTime(reader["CreatedAt"]),
                        Status = (CaseStatus)Enum.Parse(typeof(CaseStatus), reader["Status"].ToString())
                    };
                }
                return null;
            }
        }

        public void Update(Case updatedCase)
        {
            using (SqlConnection connection = new SqlConnection(_CaseManagementDBConnectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Cases SET CustomerFirstName = @customerFirstName, CustomerLastName = @customerLastName, CustomerEmail = @customerEmail, CustomerPhone = @customerPhone, Description = @description, CreatedAt = @createdAt, Status = @status WHERE CaseId = @caseId", connection);
                cmd.Parameters.AddWithValue("@caseId", updatedCase.CaseId);
                cmd.Parameters.AddWithValue("@customerFirstName", updatedCase.CustomerFirstName);
                cmd.Parameters.AddWithValue("@customerLastName", updatedCase.CustomerLastName);
                cmd.Parameters.AddWithValue("@customerEmail", updatedCase.CustomerEmail);
                cmd.Parameters.AddWithValue("@customerPhone", updatedCase.CustomerPhone);
                cmd.Parameters.AddWithValue("@description", updatedCase.Description);
                cmd.Parameters.AddWithValue("@createdAt", updatedCase.CreatedAt);
                cmd.Parameters.AddWithValue("@status", (int)updatedCase.Status);
                cmd.ExecuteNonQuery();
            }
        }



        public void CreateCase(Case newCase)
        {
            using (var connection = new SqlConnection(_CaseManagementDBConnectionString))
            {
                var command = new SqlCommand("INSERT INTO Cases (CustomerFirstName, CustomerLastName, CustomerEmail, CustomerPhone, Description, CreatedAt, Status) VALUES (@firstName, @lastName, @email, @phoneNumber, @description, @createdAt, @status)", connection);
                command.Parameters.AddWithValue("@firstName", newCase.CustomerFirstName);
                command.Parameters.AddWithValue("@lastName", newCase.CustomerLastName);
                command.Parameters.AddWithValue("@email", newCase.CustomerEmail);
                command.Parameters.AddWithValue("@phoneNumber", newCase.CustomerPhone);
                command.Parameters.AddWithValue("@description", newCase.Description);
                command.Parameters.AddWithValue("@createdAt", newCase.CreatedAt);
                command.Parameters.AddWithValue("@status", newCase.Status.ToString());

                connection.Open();

                command.ExecuteNonQuery();

                
                newCase.CaseId = (int)command.ExecuteScalar();
            }
        }

        public void Insert(Case newCase)
        {
            using (SqlConnection connection = new SqlConnection(_CaseManagementDBConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO Cases (CustomerFirstName, CustomerLastName, CustomerEmail, CustomerPhone, Description, CreatedAt, Status) " +
                    "VALUES (@CustomerFirstName, @CustomerLastName, @CustomerEmail, @CustomerPhone, @Description, @CreatedAt, @Status)", connection);
                command.Parameters.AddWithValue("@CustomerFirstName", newCase.CustomerFirstName);
                command.Parameters.AddWithValue("@CustomerLastName", newCase.CustomerLastName);
                command.Parameters.AddWithValue("@CustomerEmail", newCase.CustomerEmail);
                command.Parameters.AddWithValue("@CustomerPhone", newCase.CustomerPhone);
                command.Parameters.AddWithValue("@Description", newCase.Description);
                command.Parameters.AddWithValue("@CreatedAt", newCase.CreatedAt);
                command.Parameters.AddWithValue("@Status", (int)Enum.Parse(typeof(CaseStatus), newCase.Status));
                command.ExecuteNonQuery();
            }
        }




        public void Insert(Case newCase)
        {
            using (var context = new CaseManagementDBContext(_CaseManagementDBConnectionString))
            {
                context.Cases.Add(newCase);
                context.SaveChanges();
            }
        }
    }   

}
