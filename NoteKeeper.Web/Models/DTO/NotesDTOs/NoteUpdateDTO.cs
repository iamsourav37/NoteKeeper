using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace NoteKeeper.Web.Models.DTO.NotesDTOs
{
    public class NoteUpdateDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        [DisplayName("Display Name")]
        public string NoteContent { get; set; }
        public string? Color { get; set; } = "White";
        public Guid UserId { get; set; }
    }
}
