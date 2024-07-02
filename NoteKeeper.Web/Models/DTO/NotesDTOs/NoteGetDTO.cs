using NoteKeeper.Web.Models.Domain.Account;
using System.ComponentModel;

namespace NoteKeeper.Web.Models.DTO.NotesDTOs
{
    public class NoteGetDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string NoteContent { get; set; }
        public string Color { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
