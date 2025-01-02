using DAL.Entities;
using DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services;

public class ContactService : IContactService
{
    private readonly IContactRepository _repo;

    public ContactService(IContactRepository repo)
    {
        _repo = repo;
    }

    public async Task<bool> AddManyAsync(IEnumerable<Contact> contacts)
    {
        return await _repo.AddManyAsync(contacts);
    }

    public async Task DeleteAsync(int id)
    {
        var data = await _repo.GetAsync(id);
        await _repo.DeleteAsync(data!);
    }

    public async Task<List<Contact>> GetAllAsync()
    {
        return await _repo.GetAllAsync();
    }

    public async Task<Contact> GetAsync(int id)
    {
        return await _repo.GetAsync(id);
    }

    public async Task<Contact> UpdateAsync(Contact contact)
    {
        return await _repo.UpdateAsync(contact);
    }
}
