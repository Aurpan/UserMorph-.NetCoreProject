namespace DataMorph.Core.DTOs.PersistenceModels
{
    public class UserContact
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
