using AutoMapper;
using BlogSystem.Data.Models;
using BlogSystem.Web.Areas.Administration.ViewModels.Administration;
using BlogSystem.Web.Infrastructure.Mapping;

namespace BlogSystem.Web.Areas.Administration.ViewModels
{
    public class CustomerContactViewModel : AdministrationViewModel, IMapFrom<CustomerContact>, IHaveCustomMappings
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public string Type { get; set; }

        public void CreateMappings(IMapperConfigurationExpression config)
        {
            config.CreateMap<CustomerContact, CustomerContactViewModel>();
        }
    }
}