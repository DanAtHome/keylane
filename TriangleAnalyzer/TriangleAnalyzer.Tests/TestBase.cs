using System;
using CommonServiceLocator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unity;

namespace TriangleAnalyzer.Tests
{
    [TestClass]
    public class TestBase
    {
        private static IUnityContainer _unityContainer = null;
        private static IServiceLocator _serviceLocator = null;

        private static IUnityContainer UnityContainer
        {
            get { return _unityContainer ?? (_unityContainer = UnityConfig.GetUnityContainer()); }
        }

        private static IServiceLocator ServiceLocator
        {
            get { return _serviceLocator ?? (_serviceLocator = UnityContainer.Resolve<IServiceLocator>()); }
        }

        protected TService GetService<TService>()
        {
            return ServiceLocator.Get<TService>();
        }
    }
}
