using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Reload.Common.Authentication.Mvc;
using Reload.Repository;
using Reload.Service;
using Reload.Web.Attributes;
using Reload.Web.Controllers;

namespace Reload.Web.Configuration
{
	/// <summary>The dependency configuration class.</summary>
	public static class DependencyConfig
	{
		/// <summary>Configures the dependencies.</summary>
		public static void Initialize()
		{
			DependencyResolver.SetResolver(new AutofacDependencyResolver(RegisterServices()));
		}

		/// <summary>Registers the services as dependencies.</summary>
		private static IContainer RegisterServices()
		{
			ContainerBuilder builder = new ContainerBuilder();

			builder.RegisterAssemblyTypes(typeof(MvcApplication).Assembly).PropertiesAutowired();

			// Auto register all Services.
			builder.RegisterAssemblyTypes(typeof(BaseService).Assembly)
				.Where(t => t.Name.EndsWith("Service"))
				.AsImplementedInterfaces()
				.PropertiesAutowired();

			// Auto register all Repositories.
			builder.RegisterAssemblyTypes(typeof(BaseRepository<>).Assembly)
				.Where(t => t.Name.EndsWith("Repository"))
				.AsImplementedInterfaces()
				.PropertiesAutowired();

			builder.Register(x => { return MvcAuthentication.GetUser(); })
				.As<IUserIdentity>();

			builder.RegisterFilterProvider();

			// Register global exception handling attribute.
			builder.RegisterType<HandleExceptionAttribute>()
				.AsExceptionFilterFor<BaseController>()
				.PropertiesAutowired();

			return builder.Build();
		}
	}
}