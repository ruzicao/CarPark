using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using CarPark.Models;
using CarPark.Repository;
using CarPark.Repository.Interfaces;
using CarPark.Resolver;
using Microsoft.Owin.Security.OAuth;
using Microsoft.Practices.Unity;
using Newtonsoft.Json.Serialization;

namespace CarPark
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Car, CarDTO>();
                cfg.CreateMap<Manufacturer, ManufacturerDTO>(); 
            });

            config.EnableSystemDiagnosticsTracing();

            // Unity
            var container = new UnityContainer();
            container.RegisterType<ICarRepository, CarRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IManufacturerRepository, ManufacturerRepository>(new HierarchicalLifetimeManager());

            config.DependencyResolver = new UnityResolver(container);
        }
    }
}
