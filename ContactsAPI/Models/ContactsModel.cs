namespace ContactsAPI.Models
{
    public class ContactsModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string? CompanyName { get; set; }
    }
}
