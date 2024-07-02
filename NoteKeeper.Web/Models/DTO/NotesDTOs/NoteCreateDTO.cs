using NoteKeeper.Web.Models.Domain.Account;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NoteKeeper.Web.Models.DTO.NotesDTOs
{
    public class NoteCreateDTO
    {
        [Required]
        public string Title { get; set; }

        [Required]
        [DisplayName("Display Name")]
        public string NoteContent { get; set; }
        public string? Color { get; set; } = "White";
        public Guid UserId { get; set; }
    }
}
