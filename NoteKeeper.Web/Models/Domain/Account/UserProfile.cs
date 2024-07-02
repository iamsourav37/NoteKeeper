using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;

namespace NoteKeeper.Web.Models.Domain.Account
{

    public enum Gender
    {
        Male, Female
    }
    public class UserProfile : IdentityUser<Guid>
    {
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public string Country { get; set; }
        public string State { get; set; }

        public ICollection<Note> Notes { get; set; }
    }
}
