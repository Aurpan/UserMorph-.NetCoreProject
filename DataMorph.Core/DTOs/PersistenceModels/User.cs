using DataMorph.Core.Enums;

namespace DataMorph.Core.DTOs.PersistenceModels
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }
        public string Company { get; set; }
        public Gender Sex { get; set; }
    }
}
