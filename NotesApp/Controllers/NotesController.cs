using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NotesApp.Models;
using NotesApp.Data;

namespace NotesApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class NotesController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public NotesController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpPost]
        [Route("/create")]
        public IActionResult CreateNoteEntry(NotesEntries note)
        {
            if (note != null)
            {
                _db.Notes.Add(note);
                _db.SaveChanges();

                return new JsonResult(new { Message = "Note created successfully" });
            }
            else
            {
                return BadRequest("Invalid note data");
            }
        }

        [HttpGet]
        [Route("/list")]
        public IActionResult GetNotes()
        {
            List<NotesEntries> result = _db.Notes.ToList();

            if (result == null)
            {
                return new JsonResult(NotFound());
            }

            return new JsonResult(Ok(result));
        }

        [HttpGet]
        [Route("/get-note")]
        public IActionResult GetNoteById(int id)
        {

            NotesEntries result = _db.Notes.Find(id);

            if (result == null)
            {
                return new JsonResult(NotFound());
            }

            return new JsonResult(Ok(result));
        }

        [HttpPut]
        [Route("/update")]
        public IActionResult UpdateNote(NotesEntries note)
        {
            if (note.Title != null)
            {
                NotesEntries result = _db.Notes.Find(note.Id);

                if (result == null)
                    return new JsonResult(NotFound());

                result.Title = note.Title;
                result.Description = note.Description;

                _db.SaveChanges();
            }
            else
            {
                return new JsonResult(BadRequest());
            }

            return new JsonResult(Ok());
        }

        [HttpDelete]
        [Route("/delete")]
        public IActionResult DeleteNoteById(int id)
        {
            NotesEntries result = _db.Notes.Find(id);

            if (result == null)
            {
                return new JsonResult(NotFound());
            }

            _db.Notes.Remove(result);
            _db.SaveChanges();

            return new JsonResult(Ok());
        }
    }
}
