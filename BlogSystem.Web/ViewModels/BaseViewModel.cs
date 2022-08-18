using System;
using System.ComponentModel.DataAnnotations;

namespace BlogSystem.Web.ViewModels
{
    public class BaseViewModel
    {
        [DisplayFormat(DataFormatString = "{0:dd MMMM yyyy}")]
        public DateTime CreatedOn { get; set; }
    }
}