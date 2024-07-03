using NoteKeeper.Web.Models.DTO.NotesDTOs;

namespace NoteKeeper.Web.Repository
{
    public interface INote
    {
        Task<IEnumerable<NoteGetDTO>> GetNotesAsync(Guid userId);
        Task<NoteGetDTO> GetNoteByIdAsync(Guid userId, Guid noteId);
        Task<NoteGetDTO> CreateNoteAsync(NoteCreateDTO noteCreateDTO);
        Task<NoteGetDTO> UpdateNoteAsync(NoteUpdateDTO noteUpdateDTO);
        Task<bool> DeleteAsync(Guid id);
    }
}
