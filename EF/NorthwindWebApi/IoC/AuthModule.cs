using Autofac;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace NorthwindWebApi.IoC
{
    public class AuthModule : Autofac.Module
    {
        private readonly IConfiguration _configuration;
        public AuthModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.Register(ctx =>
            {
                return new AuthTokenSettings(_configuration);
            }).As<AuthTokenSettings>();
            builder.RegisterType<AuthService>().As<IAuthService>().InstancePerDependency();
            builder.RegisterType<AuthService>().As<IAuthService>();
        }
    }
}
