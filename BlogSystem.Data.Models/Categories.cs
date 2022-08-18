using BlogSystem.Data.Contracts.Models;

namespace BlogSystem.Data.Models
{
    internal class Categories : BaseModel<int>
    {

        public string ParentID { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public string Description { get; set; }
        public bool ShowOnHomePage { get; set; }
        public bool Published { get; set; }
        public int DisplayOrder { get; set; }
    }
}
