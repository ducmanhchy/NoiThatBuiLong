using BlogSystem.Data.Contracts.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogSystem.Data.Models
{
    internal class Products : BaseModel<int>
    {
        public Products()
            : base()
        {
            Categories = new HashSet<Categories>();
        }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
        public bool ShowOnHomePage { get; set; }
        public int HomePageDisplayOrder { get; set; }
        public decimal OldPrice { get; set; }
        public decimal ProductCost { get; set; }
        public decimal? SpecialPrice { get; set; }
        public DateTime? SpecialPriceStartDateTimeUtc { get; set; }
        public DateTime? SpecialPriceEndDateTimeUtc { get; set; }
        public bool HasTierPrices { get; set; }
        public decimal Weight { get; set; }
        public decimal Length { get; set; }
        public decimal Width { get; set; }
        public decimal Height { get; set; }
        public int DisplayOrder { get; set; }
        public virtual ICollection<Categories> Categories { get; set; }
        [Required]
        public string AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public virtual ApplicationUser Author { get; set; }

    }
}
