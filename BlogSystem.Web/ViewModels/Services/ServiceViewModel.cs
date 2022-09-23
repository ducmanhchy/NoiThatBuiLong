﻿using AutoMapper;
using BlogSystem.Data.Models;
using BlogSystem.Web.Infrastructure.Mapping;
using System.Collections.Generic;

namespace BlogSystem.Web.ViewModels.Services
{
    public class ServiceViewModel : BaseViewModel, IMapFrom<Post>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string ShortContent { get; set; }

        public string AuthorId { get; set; }

        public string Author { get; set; }

        public bool isPublish { get; set; }

        public string type { get; set; }

        public string ParentType { get; set; }

        public string linkIMG { get; set; }

        public string TitleIMG { get; set; }

        public string Desc { get; set; }

        public string LinkPost { get; set; }

        public int Ord { get; set; }

        public IEnumerable<ServiceViewModel> Posts { get; set; }

        public void CreateMappings(IMapperConfigurationExpression config)
        {
            config.CreateMap<Service, ServiceViewModel>().ForMember(m => m.Author, c => c.MapFrom(p => p.Author.UserName));
        }
    }
}