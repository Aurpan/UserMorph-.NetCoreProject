using UserMorph.Core.Enums;

namespace UserMorph.Core.DTOs.DomainModels
{
    public class Role
    {
        public UserRole RoleId { get; set; }
        public int UserId { get; set; }
    }
}
