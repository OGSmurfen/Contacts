using ContactsAPI.Data;
using ContactsAPI.Models;
using ContactsAPI.Repository.IRepository;
using System.Linq.Expressions;

namespace ContactsAPI.Repository.RepositoryImpl
{
    public class ContactsReposiotry : Repository<ContactsModel>, IContactsRepository
    {
        private readonly ContactsDbContext contactsDbContext;
        public ContactsReposiotry(ContactsDbContext contactsDbContext) : base(contactsDbContext)
        {
            this.contactsDbContext = contactsDbContext;
        }

        public bool ContactsExists(int id)
        {

            return contactsDbContext.Contacts.Any(c => c.Id == id);
        }

    }
}
