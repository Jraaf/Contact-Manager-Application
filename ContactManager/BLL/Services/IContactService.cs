using DAL.Entities;

namespace BLL.Services;

public interface IContactService
{
    Task<List<Contact>> GetAllAsync();
    Task<Contact> GetAsync(int id);
    Task<bool> AddManyAsync(IEnumerable<Contact> contacts);
    Task<Contact> UpdateAsync(Contact contact);
    Task DeleteAsync(int id);
}
