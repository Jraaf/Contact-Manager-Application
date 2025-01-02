using BLL.Services;
using DAL.EF;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ContactManager.Controllers;

public class ContactController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly IContactService _service;

    public ContactController(ApplicationDbContext context, IContactService service)
    {
        _context = context;
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var Contacts = await _service.GetAllAsync();
        return View(Contacts);
    }

    [HttpPost]
    public async Task<IActionResult> UploadCsv(IFormFile file)
    {
        if (file == null || file.Length == 0)
            return BadRequest("No file uploaded.");

        using var reader = new StreamReader(file.OpenReadStream());
        var contacts = new List<Contact>();
        while (!reader.EndOfStream)
        {
            var line = await reader.ReadLineAsync();
            var values = line.Split(',');

            if (values.Length != 5)
                return BadRequest("Invalid CSV format.");

            var contact = new Contact
            {
                Name = values[0],
                DateOfBirth = DateOnly.Parse(values[1]),
                Married = bool.Parse(values[2]),
                Phone = values[3],
                Salary = decimal.Parse(values[4])
            };
            contacts.Add(contact);
        }

        await _service.AddManyAsync(contacts);
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Contact Contact)
    {
        if (!ModelState.IsValid)
            return BadRequest("Invalid data.");

        await _service.UpdateAsync(Contact);
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);
        return Ok();
    }
}

