using BlogSystem.Data.Contracts.Models;

namespace BlogSystem.Data.Models
{
    public class CustomerContact : BaseModel<int>
    {
        public CustomerContact()
        {

        }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public string Type { get; set; }
    }
}
