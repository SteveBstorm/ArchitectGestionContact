using GestionContact.DAL.Interface;
using GestionContact.DAL.Models;
using GestionContact.DAL.Tools;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionContact.DAL.Services
{
    public class ContactRepository : IContactRepository
    {
        private const string connectionString = @"Data Source=STEVEBSTORM\MSSQLSERVER01;Initial Catalog=ArchitectContact;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        
        private SqlConnection _connection;
        public ContactRepository(SqlConnection connection)
        {
            _connection = connection;
        }
        
        public bool Create(Contact contact)
        {
            string sqlQuery = "INSERT INTO Contact (Firstname, Lastname,Email, Phone) " +
                              "VALUES (@firstname, @lastname, @email, @phone)";

            using(SqlConnection c = _connection)
            {
                //c.ConnectionString = connectionString;

                using(SqlCommand cmd = c.CreateCommand())
                {
                    cmd.CommandText = sqlQuery;
                    cmd.Parameters.AddWithValue("firstname", contact.Firstname);
                    cmd.Parameters.AddWithValue("lastname", contact.Lastname);
                    cmd.Parameters.AddWithValue("email", contact.Email);
                    cmd.Parameters.AddWithValue("phone", contact.Phone);

                    bool result;
                    c.Open();
                    result = cmd.ExecuteNonQuery() > 0;
                    c.Close();
                    return result;
                }
            }
        
        }

        public bool Delete(int id)
        {
            bool result;
            using(SqlConnection c = _connection)
            {
               
                using (SqlCommand cmd = c.CreateCommand())
                {
                    string sql = "DELETE FROM Contact WHERE Id = @id";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("id", id);

                    c.Open();
                    result = cmd.ExecuteNonQuery() > 0;
                    c.Close();
                    return result;
                }
            }
        }

        public IEnumerable<Contact> GetAll()
        {
            List<Contact> result = new List<Contact>();
            using(SqlConnection c = _connection)
            {
                

                using (SqlCommand cmd = c.CreateCommand())
                {
                    string sql = "SELECT * FROM Contact";
                    cmd.CommandText = sql;
                    c.Open();
                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(reader.MapContact());
                        }
                    }
                    c.Close();
                }
            }
            return result;
        }

        public Contact GetById(int id)
        {
            Contact result = new Contact();
            using (SqlConnection c = _connection)
            {
                

                using (SqlCommand cmd = c.CreateCommand())
                {
                    string sql = "SELECT * FROM Contact WHERE Id = @id";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("id", id);
                    c.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            result = reader.MapContact();
                        }
                    }
                    c.Close();
                }
            }
            return result;
        }

        public bool Update(Contact contact)
        {
            string sqlQuery = "UPDATE Contact SET Lastname = @lastname, Firstname = @firstname" +
                " Email = @email, Phone = @phone WHERE Id = @id";

            using (SqlConnection c = _connection)
            {
                
                using (SqlCommand cmd = c.CreateCommand())
                {
                    cmd.CommandText = sqlQuery;
                    cmd.Parameters.AddWithValue("firstname", contact.Firstname);
                    cmd.Parameters.AddWithValue("lastname", contact.Lastname);
                    cmd.Parameters.AddWithValue("email", contact.Email);
                    cmd.Parameters.AddWithValue("phone", contact.Phone);
                    cmd.Parameters.AddWithValue("id", contact.Id);

                    bool result;
                    c.Open();
                    result = cmd.ExecuteNonQuery() > 0;
                    c.Close();
                    return result;
                }
            }
        }
    }
}
