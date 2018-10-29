using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using TriangleAnalyzer.Infrastructure.Context;
using TriangleAnalyzer.Infrastructure.Queues;
using TriangleAnalyzer.Infrastructure.Repositories;
using TriangleAnalyzer.Service.Interfaces;
using TriangleAnalyzer.Service.Interfaces.Infrastructure;
using TriangleAnalyzer.Service.Interfaces.Infrastructure.Queues;
using TriangleAnalyzer.Service.Interfaces.Infrastructure.Repositories;
using TriangleAnalyzer.Service.Services;
using Unity;
using Unity.Lifetime;

namespace TriangleAnalyzer.API.App_Start
{
    public static class UnityConfig
    {
        public static void ConfigureUnity(HttpConfiguration config)
        {
            var container = new UnityContainer();

            container.RegisterType<TriangleAnalyzerDB, TriangleAnalyzerDB>(new TransientLifetimeManager());

            //Queue
            container.RegisterType<ITriangleMessageQueue, TriangleMessageQueue>(new TransientLifetimeManager());

            //Services
            container.RegisterType<ITriangleService, TriangleService>(new TransientLifetimeManager());

            //Repositories
            container.RegisterType<ITriangleRepository, TriangleRepository>(new TransientLifetimeManager());
            container.RegisterType<ITriangleStageRepository, TriangleStageRepository>(new TransientLifetimeManager());

            config.DependencyResolver = new UnityResolver(container);
        }
    }
}