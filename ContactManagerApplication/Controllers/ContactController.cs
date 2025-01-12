using ContactManagerApplication.DTOs;
using ContactManagerApplication.Processor;
using ContactManagerApplication.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ContactManagerApplication.Controllers
{
    public class ContactController(IFileProcessor _fileProcessor, IContactService _contactService) : Controller
    {
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            IEnumerable<ContactGetDto> results = await _contactService.GetAllAsync();
            return View(results);
        }

        [HttpPost]
        public async Task<ActionResult> UploadCsv(IFormFile file)
        {
            var data = _fileProcessor.ReadFile(file);
            var entities = await _contactService.AddRangeAsync(data);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<ActionResult> Update(Guid id, ContactUpdateDto contact)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                throw new ArgumentException($"Model validation failed: {string.Join("; ", errors)}");
            }
            await _contactService.UpdateAsync(id, contact);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _contactService.DeleteByIdAsync(id);
            return RedirectToAction("Index");
        }
    }
}
