using CommonServiceLocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

namespace TriangleAnalyzer.Tests
{
    public class UnityRegistrationModule : IContainerRegistrationModule<IUnityContainer>
    {
        // Register dependencies in unity container
        public void Register(IUnityContainer container)
        {
            // register service locator
            container.RegisterType<IServiceLocator, CustomUnityServiceLocator>();

            // register services
            container.RegisterType<TriangleAnalyzerDB, TriangleAnalyzerDB>(new TransientLifetimeManager());

            //Queue
            container.RegisterType<ITriangleMessageQueue, TriangleMessageQueue>(new TransientLifetimeManager());

            //Services
            container.RegisterType<ITriangleService, TriangleService>(new TransientLifetimeManager());

            //Repositories
            container.RegisterType<ITriangleRepository, TriangleRepository>(new TransientLifetimeManager());
            container.RegisterType<ITriangleStageRepository, TriangleStageRepository>(new TransientLifetimeManager());

        }
    }
}
