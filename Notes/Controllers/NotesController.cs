using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Notes.DBModels;
using Notes.Dtos;
using Notes.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace Notes.Controllers
{
    [Route("[controller]/[action]")]
    [Authorize]
    public class NotesController : Controller
    {
        private readonly ILogger<NotesController> _logger;
        private readonly INoteRepository _noteRepository;
        private readonly IMapper _mapper;

        public NotesController(
            INoteRepository noteRepository,
            IMapper mapper,
            ILogger<NotesController> logger)
        {
            _logger = logger;
            _mapper = mapper;
            _noteRepository = noteRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var notes = _noteRepository.GetAll(User.FindFirstValue(ClaimTypes.NameIdentifier));
            return View(_mapper.Map<IEnumerable<NoteReadDto>>(notes).ToList());
        }

        [HttpPost]
        public ActionResult<NoteReadDto> CreateNote(NoteWriteDto noteDto)
        {
            var note = _mapper.Map<Note>(noteDto);

            note.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            _noteRepository.Create(note);

            return RedirectToAction("Index", "Notes");

            //var noteReadDto = _mapper.Map<NoteReadDto>(note);

            //return CreatedAtRoute(nameof(CreateNote),
              //  new { noteId = noteReadDto.Id }, noteReadDto);
        }

        [HttpPatch]
        public ActionResult<NoteReadDto> UpdateNote(NoteReadDto noteDto)
        {
            var note = _noteRepository.Get(noteDto.Id, User.FindFirstValue(ClaimTypes.NameIdentifier));

            if (note == null)
            {
                return NotFound();
            }

            note.Content = noteDto.Content;

            _noteRepository.Update(note);

            return CreatedAtRoute(nameof(CreateNote),
                new { noteId = note.Id }, _mapper.Map<NoteReadDto>(note));
        }

        [HttpGet("{noteId}")]
        //[HttpDelete("{noteId}")]
        public ActionResult DeleteNote([FromRoute] int noteId)
        {
            var note = _noteRepository.Get(noteId, User.FindFirstValue(ClaimTypes.NameIdentifier));

            if (note != null)
            {
                _noteRepository.Delete(note);
            }

            return RedirectToAction("Index", "Notes");
        }
    }
}
