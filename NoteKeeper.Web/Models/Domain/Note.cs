using NoteKeeper.Web.Models.Domain.Account;
using System.ComponentModel.DataAnnotations;

namespace NoteKeeper.Web.Models.Domain
{
    public class Note
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string NoteContent { get; set; }
        public string? Color { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Guid UserId { get; set; }
        public UserProfile UserProfile { get; set; }
    }
}
