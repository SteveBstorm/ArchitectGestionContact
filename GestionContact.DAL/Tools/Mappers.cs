using GestionContact.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionContact.DAL.Tools
{
    internal static class Mappers
    {
        internal static Contact MapContact(this SqlDataReader reader)
        {
            return new Contact
            {
                Id = (int)reader["Id"],
                Lastname = (string)reader["Lastname"],
                Firstname = (string)reader["Firstname"],
                Phone = (string)reader["Phone"],
                Email = (string)reader["Email"],
                IsActive = (bool)reader["IsActive"]
            };
        }
    }
}
