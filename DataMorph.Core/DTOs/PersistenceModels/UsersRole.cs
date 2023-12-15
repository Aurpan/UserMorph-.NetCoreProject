using UserMorph.Core.Enums;

namespace UserMorph.Core.DTOs.PersistenceModels
{
    public class UsersRole
    {
        public UserRole RoleId { get; set; }
        public int UserId { get; set; }

        public User User { get; set; }
    }
}
