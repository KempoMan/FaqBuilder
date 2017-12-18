using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using FaqBuilder.Models;
using FaqBuilder.ViewModels;

namespace FaqBuilder
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Platform, PlatformViewModel>().ForMember(t => t.Id, opt => opt.Ignore()).ReverseMap();
                cfg.CreateMap<Game, GameViewModel>();
                cfg.CreateMap<GameViewModel, Game>()
                    .ForMember(t => t.Id, opt => opt.Ignore())
                    .ForMember(t => t.Characters, opt => opt.Ignore());
                cfg.CreateMap<Character, CharacterViewModel>();
            });
        }
    }
}
