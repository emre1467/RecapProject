using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete.EFramework;
using DataAccess.Concrete.NewFolder;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CarManager>().As<ICarService>().SingleInstance();
            builder.RegisterType<ColorManager>().As<IColorService>().SingleInstance();
            builder.RegisterType<UsersManager>().As<IUsersService>().SingleInstance();
            builder.RegisterType<RentalsManager>().As<IRentalsService>().SingleInstance();
            builder.RegisterType<CustomerManager>().As<ICustomersService>().SingleInstance();
            builder.RegisterType<EfCarDal>().As<ICarDal>().SingleInstance();
            builder.RegisterType<EfColorDal>().As<IColorDal>().SingleInstance();
            builder.RegisterType<EfUsersDal>().As<IUsersDal>().SingleInstance();
            builder.RegisterType<EfRentalsDal>().As<IRentalsDal>().SingleInstance();
            builder.RegisterType<EfCustomersDal>().As<ICustomersDal>().SingleInstance();

            builder.RegisterType<EfCarImagesDal>().As<ICarImageDal>().SingleInstance();
            builder.RegisterType<CarImageManager>().As<ICarImageService>().SingleInstance();


            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();

        }
    }
}
