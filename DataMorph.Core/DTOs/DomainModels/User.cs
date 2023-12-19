using UserMorph.Core.Enums;

namespace UserMorph.Core.DTOs.DomainModels
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }
        public string Company { get; set; }
        public Gender Sex { get; set; }

        public IEnumerable<UserContact> Contacts { get; set; }
        public IEnumerable<Role> Roles { get; set; }
    }
}
