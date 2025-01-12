using ContactManagerApplication.DTOs;
using ContactManagerApplication.Models;
using ContactManagerApplication.Processor;
using ContactManagerApplication.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContactManagerApplication.Controllers
{
    [Controller]
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
            if (file == null || file.ContentLength == 0)
            {
                ViewBag.Error = "File is missing or empty.";
                return View("Error");
            }
            var data = _fileProcessor.ReadFile(file.OpenReadStream());
            await _contactService.
            return RedirectToAction("Index");
        }

        [HttpPatch]
        public async Task<ActionResult> Update(ContactUpdateDto contact)
        {
            if (!ModelState.IsValid)
                return new HttpStatusCodeResult(400);

            await _service.UpdateContactAsync(contact);
            return new HttpStatusCodeResult(200);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            await _contactService.DeleteByIdAsync(id);
            return RedirectToAction("Index");
        }
    }
}
