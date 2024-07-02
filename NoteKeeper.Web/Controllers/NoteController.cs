using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NoteKeeper.Web.Models.DTO.NotesDTOs;
using NoteKeeper.Web.Repository;
using System.Security.Claims;

namespace NoteKeeper.Web.Controllers
{
    [Authorize]
    public class NoteController : Controller
    {
        private readonly INote _note;

        public NoteController(INote note)
        {
            this._note = note;
        }

        private Guid GetUserId()
        {
            return Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
        }
        public async Task<IActionResult> Index()
        {
            var userId = this.GetUserId();
            var result = await this._note.GetNotesAsync(userId);
            return View(result);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NoteCreateDTO noteCreateDTO)
        {
            if(!ModelState.IsValid)
            {
                return View(noteCreateDTO);
            }
            noteCreateDTO.UserId = this.GetUserId();
            await this._note.CreateNoteAsync(noteCreateDTO);
            return RedirectToAction("Index");   
        }
    }
}
