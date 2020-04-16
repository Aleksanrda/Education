using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Task5.Core.Entities;
using Task5.Core.Repositories;
using Task5.DataAccess.Repositories;

namespace Task5.Web.App_Start
{
    public class ContainerConfig
    {
        internal static void RegisterContainer(HttpConfiguration httpConfiguration)
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterApiControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().SingleInstance();

            builder.RegisterType(typeof(Repository<Flower>))
                .As(typeof(IRepository<Flower>))
                .SingleInstance();

            builder.RegisterType(typeof(Repository<Plantation>))
                .As(typeof(IRepository<Plantation>))
                .SingleInstance();

            builder.RegisterType(typeof(Repository<Warehouse>))
                .As(typeof(IRepository<Warehouse>))
                .SingleInstance();

            builder.RegisterType(typeof(Repository<PlantationFlower>))
                .As(typeof(IRepository<PlantationFlower>))
                .SingleInstance();

            builder.RegisterType(typeof(Repository<WarehouseFlower>))
                .As(typeof(IRepository<WarehouseFlower>))
                .SingleInstance();

            builder.RegisterType(typeof(Repository<Supply>))
                .As(typeof(IRepository<Supply>))
                .SingleInstance();

            builder.RegisterType(typeof(Repository<SupplyFlower>))
                .As(typeof(IRepository<SupplyFlower>))
                .SingleInstance();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            httpConfiguration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}