using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TriangleAnalyzer.Infrastructure.Context;
using TriangleAnalyzer.Infrastructure.Repositories;
using TriangleAnalyzer.Service.Interfaces.Infrastructure.Repositories;
using TriangleAnalyzer.Service.Interfaces.Service;
using TriangleAnalyzer.Service.Services;
using Unity;
using Unity.Lifetime;

namespace TriangleAnalyzer.Batch
{
    public class Program
    {
        private static readonly ILog _logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        
        static void Main(string[] args)
        {

            Console.WriteLine("Registering dependencies ...");
            var container = new UnityContainer();
            container.RegisterType<BatchRunner, BatchRunner>(); 

            RegisterTypes(container);

            var program = container.Resolve<BatchRunner>();

            Console.WriteLine("All done. Starting program...");

            try
            {
                program.Run();
            }
            catch(Exception ex)
            {
                _logger.Error("Fatal error executing batchjob", ex);
            }            
        }

        private static void RegisterTypes(UnityContainer container)
        {
            container.RegisterType<ITriangleProcessRepository, TriangleProcessRepository>(new ContainerControlledLifetimeManager());
            container.RegisterType<ITriangleProcessService, TriangleProcessService>(new ContainerControlledLifetimeManager());
            container.RegisterType<TriangleAnalyzerDB, TriangleAnalyzerDB>(new ContainerControlledLifetimeManager());
        }
    }
}
