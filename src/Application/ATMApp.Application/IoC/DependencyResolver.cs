using ATMApp.Application.Mapper;
using ATMApp.Application.Services.MailService;
using ATMApp.Application.Services.TokenService;
using ATMApp.Application.Services.UserProcessService;
using ATMApp.Application.Services.UserService;
using ATMApp.Domain.Repositories;
using ATMApp.Infrastructure.Repositories;
using Autofac;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMApp.Application.IoC
{
    public class DependencyResolver : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MailService>().As<IMailService>().InstancePerLifetimeScope();
            builder.RegisterType<TokenHandler>().As<ITokenHandler>().InstancePerLifetimeScope();
            builder.RegisterType<UserService>().As<IUserService>().InstancePerLifetimeScope();
            builder.RegisterType<UserProcessService>().As<IUserProcessService>().InstancePerLifetimeScope();


            builder.RegisterType<UserRepo>().As<IUserRepo>().InstancePerLifetimeScope();
            builder.RegisterType<UserProcessRepo>().As<IUserProcessRepo>().InstancePerLifetimeScope();

            builder.Register(context => new MapperConfiguration(cfg =>
            {
                //Register Mapper Profile
                cfg.AddProfile<Mapping>();
            }
           )).AsSelf().SingleInstance();

            builder.Register(c =>
            {
                //This resolves a new context that can be used later.
                var context = c.Resolve<IComponentContext>();
                var config = context.Resolve<MapperConfiguration>();
                return config.CreateMapper(context.Resolve);
            })
            .As<IMapper>()
            .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
