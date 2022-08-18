using BlogSystem.Data.Contracts.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogSystem.Data.Models
{
    public class MenuItem : BaseModel<int>
    {
        public MenuItem()
        {
            
        }

        [Required]
        [MinLength(3, ErrorMessage = "The {0} must be at least {1} characters long.")]
        public string Title { get; set; }

        public string Description { get; set; }

        public string MenuParent { get; set; }

        public bool isPublish { get; set; } 

        public string Link { get; set; }
    }
}
