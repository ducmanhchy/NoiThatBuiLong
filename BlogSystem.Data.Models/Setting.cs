using System.ComponentModel.DataAnnotations;

namespace BlogSystem.Data.Models
{
    public class Setting
    {
        [Key]
        public string Key { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Value { get; set; }
    }
}