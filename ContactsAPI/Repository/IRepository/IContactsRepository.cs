using ContactsAPI.Models;

namespace ContactsAPI.Repository.IRepository
{
    public interface IContactsRepository : IRepository<ContactsModel>
    {
        bool ContactsExists(int id);
    }
}
