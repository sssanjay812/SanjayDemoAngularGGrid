using System.Web.Http;
using Items.Business.Services;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;

namespace Items.Web.App_Start
{
    public static class SimpleInjector
    {
        public static void Initialize()
        {
            // 1. Create container
            var contain = new Container();

            // 2. Register types
            contain.Register<IItemsService, ItemsService>();

            // 3. Verity container (throw an exception if some required types cannot be resolved)
            contain.Verify();

            // 4. Configure WebApi dependency resolver
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(contain);
        }
    }
}