using Microsoft.EntityFrameworkCore;
using NoteKeeper.Web.Models.Data;
using NoteKeeper.Web.Models.Domain;
using NoteKeeper.Web.Models.DTO.NotesDTOs;

namespace NoteKeeper.Web.Repository
{
    public class NoteService : INote
    {

        private readonly ApplicationDBContext _dbContext;
        public NoteService(ApplicationDBContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<NoteGetDTO> CreateNoteAsync(NoteCreateDTO noteCreateDTO)
        {
            Note note = new Note()
            {
               Title = noteCreateDTO.Title,
               NoteContent = noteCreateDTO.NoteContent,
               Color = noteCreateDTO.Color,
               UserId = noteCreateDTO.UserId,
               CreatedAt = DateTime.Now,
               UpdatedAt = DateTime.Now,
            };

            this._dbContext.Notes.Add(note);
            await this._dbContext.SaveChangesAsync();
            return new NoteGetDTO() { Id = note.Id };
        }

        public Task<NoteGetDTO> GetNoteByIdAsync(Guid userId, Guid noteId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<NoteGetDTO>> GetNotesAsync(Guid userId)
        {
            return await this._dbContext.Notes.Where(e => e.UserId == userId).Select(n => new NoteGetDTO
            {
                Id = n.Id,
                Title = n.Title,
                NoteContent = n.NoteContent,
                Color = n.Color,
                CreatedAt = n.CreatedAt,
                UpdatedAt = n.UpdatedAt,
            }).ToListAsync();
        }

        public Task<NoteGetDTO> UpdateNoteAsync(NoteUpdateDTO noteUpdateDTO)
        {
            throw new NotImplementedException();
        }
    }
}
