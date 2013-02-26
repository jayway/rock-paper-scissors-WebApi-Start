using Autofac;
using Autofac.Integration.WebApi;
using System.Web.Http.Dependencies;
using ES.Lab.Api.Infrastructure.Security;

namespace ES.Lab.Api.Infrastructure
{
    public class Bootstrapper
    {
        public static IDependencyResolver Start()
        {
            var cb = new ContainerBuilder();
            RegisterCoreDependencies(cb);
            RegisterSecurity(cb);
            EventProjections(cb);
            cb.RegisterApiControllers(System.Reflection.Assembly.GetExecutingAssembly());
            return new AutofacWebApiDependencyResolver(cb.Build());
        }

        private static void RegisterCoreDependencies(ContainerBuilder cb)
        {
            cb.RegisterAssemblyTypes(System.Reflection.Assembly.GetExecutingAssembly())
                                     //System.Reflection.Assembly.GetAssembly(typeof (IApplicationService)))
                .Except<GenericAuthenticationService>()
                .Except<GenericRoleProvider>()
                .PreserveExistingDefaults()
                .AsImplementedInterfaces();
        }

        private static void EventProjections(ContainerBuilder cb)
        {
          
        }

        private static void RegisterSecurity(ContainerBuilder cb)
        {
            cb.RegisterType<BasicAuthenticationMessageHandler>()
                .AsSelf();

            cb.Register(c => new GenericAuthenticationService((u, p) => (u.EndsWith("jayway.com") && p == "eslab")))
                .AsImplementedInterfaces();

            cb.Register(c => new GenericRoleProvider(x => new[] {"Player"}))
                .AsImplementedInterfaces();
        }
    }
}