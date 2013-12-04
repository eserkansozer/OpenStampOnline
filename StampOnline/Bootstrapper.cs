using System.Web.Mvc;
using Microsoft.Practices.Unity;
using StampOnline.DataAccess;
using StampOnline.Domain;
using StampOnline.FileAccess;
using StampOnline.Models;
using Unity.Mvc4;

namespace StampOnline
{
  public static class Bootstrapper
  {
    public static IUnityContainer Initialise()
    {
      var container = BuildUnityContainer();

      DependencyResolver.SetResolver(new UnityDependencyResolver(container));

      return container;
    }

    private static IUnityContainer BuildUnityContainer()
    {
      var container = new UnityContainer();

      // register all your components with the container here
      // it is NOT necessary to register your controllers

      // e.g. container.RegisterType<ITestService, TestService>();    
      RegisterTypes(container);

      return container;
    }

    public static void RegisterTypes(IUnityContainer container)
    {
        container.RegisterType<IStampContainer, StampContainer>();
        container.RegisterType<IDataAccessor, DataAccessor>();
        container.RegisterType<IFileManager, FileManager>();
        container.RegisterType<IPdfManager, PdfManager>();
        container.RegisterType<IUserSession, UserSession>(new ContainerControlledLifetimeManager());        
    }
  }
}