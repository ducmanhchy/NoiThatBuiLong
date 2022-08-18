using BlogSystem.Web.Areas.Administration.ViewModels.Administration;
using System.Collections.Generic;

namespace BlogSystem.Web.Areas.Administration.ViewModels
{
    public class IndexCustomerContactViewModel : PaginationViewModel
    {
        public IEnumerable<CustomerContactViewModel> CustomerContact { get; set; }
    }
}