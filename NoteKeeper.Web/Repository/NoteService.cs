using Microsoft.AspNetCore.Mvc;
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

        public async Task<bool> DeleteAsync(Guid id)
        {
            var note = await this._dbContext.Notes.FindAsync(id);
            if (note is null) return false;

            this._dbContext.Notes.Remove(note);
            await this._dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<NoteGetDTO> GetNoteByIdAsync(Guid userId, Guid noteId)
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            return await _dbContext.Notes.Where(e => e.UserId == userId && e.Id == noteId).Select(n => new NoteGetDTO()
            {
                Id = n.Id,
                Title = n.Title,
                NoteContent = n.NoteContent,
                Color = n.Color,
                CreatedAt = n.CreatedAt,
                UpdatedAt = n.UpdatedAt,
            })?.FirstOrDefaultAsync();
#pragma warning restore CS8602 // Dereference of a possibly null reference.
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

        public async Task<NoteGetDTO> UpdateNoteAsync(NoteUpdateDTO noteUpdateDTO)
        {
            var note = await this._dbContext.Notes.FindAsync(noteUpdateDTO.Id);

            note.Title = noteUpdateDTO.Title;
            note.NoteContent = noteUpdateDTO.NoteContent;
            note.Color = noteUpdateDTO.Color;
            note.UpdatedAt = DateTime.Now;

            this._dbContext.Notes.Update(note);
            await this._dbContext.SaveChangesAsync();

            return new NoteGetDTO()
            {
                Id = note.Id,
                Title = note.Title,
                NoteContent = note.NoteContent,
                Color = note.Color,
                CreatedAt = note.CreatedAt,
                UpdatedAt = note.UpdatedAt
            };
        }

    }
}
