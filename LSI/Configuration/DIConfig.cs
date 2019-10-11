using AutoMapper;
using LSI.Application.Repositories;
using LSI.Application.Repositories.Interfaces;
using LSI.BusinessLogic.Services;
using LSI.BusinessLogic.Services.Interfaces;
using LSI.Configuration.Automapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unity;
using Unity.AspNet.Mvc;

namespace LSI.Configuration
{
    public static class DIConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            container.RegisterType<IExportRepository, ExportReposiotry>();
            container.RegisterType<IExportService, ExportService>();
            var config = new MapperConfiguration(cfg => cfg.AddProfile<ExportProfile>());
            container.RegisterInstance(config.CreateMapper());

            container.RegisterType<ILocalRespository, LocalRepository>();
            container.RegisterType<ILocalService, LocalService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}