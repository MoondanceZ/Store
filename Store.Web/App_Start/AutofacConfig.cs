using Autofac;
using Autofac.Integration.Mvc;
using Store.Framework.Common;
using Store.Model.DbContext;
using Store.Repository;
using Store.Web.ControllerFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Store.Web.App_Start
{
    public class AutofacConfig
    {
        /// <summary>
        /// 负责调用autofac框架实现业务逻辑层和数据仓储层程序集中的类型对象的创建        
        /// </summary>
        public static void Register()
        {
            //构造Autofac的builder容器
            var builder = new ContainerBuilder();

            builder.RegisterType<DatabaseFactory>().As<IDatabaseFactory>().InstancePerLifetimeScope();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();

            var repos = Assembly.Load("Store.Repository");
            //根据名称约定（服务层的接口和实现均以Services结尾），实现服务接口和服务实现的依赖
            builder.RegisterAssemblyTypes(repos, repos)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerLifetimeScope();

            //注册缓存接口
            //builder.RegisterType<HttpRuntimeCacheService>().As<ICacheService>();

            //注册所有的Controller类
            builder.RegisterControllers(Assembly.GetExecutingAssembly()).PropertiesAutowired();

            //创建一个正则的Autofac工作容器
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            IocContainer.SetContainer(container);
        }
    }
}