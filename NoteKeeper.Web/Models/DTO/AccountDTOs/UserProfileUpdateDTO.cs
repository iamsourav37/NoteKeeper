using NoteKeeper.Web.Models.Domain.Account;

namespace NoteKeeper.Web.Models.DTO.AccountDTOs
{
    public class UserProfileUpdateDTO
    {
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string Email { get; set; }
    }
}
