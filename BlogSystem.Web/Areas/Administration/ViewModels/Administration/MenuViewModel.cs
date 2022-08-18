using System.Collections.Generic;

namespace BlogSystem.Web.Areas.Administration.ViewModels.Administration
{
    public class MenuAdmin
    {
        public string ControlerName { get; set; }
        public string Name { get; set; }
    }
    public class MenuAdminViewModel
    {
        public List<MenuAdmin> Menus { get; set; }
    }
}