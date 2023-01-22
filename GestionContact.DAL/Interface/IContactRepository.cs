using GestionContact.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionContact.DAL.Interface
{
    public interface IContactRepository
    {
        bool Create(Contact contact);
        bool Update(Contact contact);
        Contact GetById(int id);
        IEnumerable<Contact> GetAll();
        bool Delete(int id);
        bool ReActivate(int id);
    }
}
