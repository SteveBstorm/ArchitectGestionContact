using GestionContact.DAL.Models;
using GestionContact.Models;

namespace GestionContact.Tools
{
    public static class Mappers
    {
        public static Contact ToDal(this ContactForm c)
        {
            return new Contact
            {
                Firstname = c.Firstname,
                Lastname = c.Lastname,
                Email = c.Email,
                Phone = c.Phone,
                Id = c.Id ?? 0
            };
        }

        public static ContactForm ToAsp(this Contact c)
        {
            return new ContactForm
            {
                Firstname = c.Firstname,
                Lastname = c.Lastname,
                Email = c.Email,
                Phone = c.Phone,
                Id = c.Id
            };
        }
    }
}
