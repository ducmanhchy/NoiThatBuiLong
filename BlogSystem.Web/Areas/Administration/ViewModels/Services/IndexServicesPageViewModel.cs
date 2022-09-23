using BlogSystem.Web.Areas.Administration.ViewModels.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogSystem.Web.Areas.Administration.ViewModels.Services
{
    public class IndexServicesPageViewModel : PaginationViewModel
    {
        public IEnumerable<ServiceViewModel> Posts { get; set; }
        public IEnumerable<string> Galleries { get; set; }
    }
}