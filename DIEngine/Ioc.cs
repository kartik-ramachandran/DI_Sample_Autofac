
using Autofac;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace DIEngine
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public static class Ioc
    {
        public static IContainer Container { get; set; }

        public static ContainerBuilder Builder { get; set; }

        public static void Register()
        {
            Builder = new ContainerBuilder();

            Builder.RegisterAssemblyTypes(GetAssembliesToRegister())
            .Where(t => t.GetCustomAttributes(typeof(RegisterServiceAttribute), false).Any())            
            .AsImplementedInterfaces().InstancePerRequest();                                 
        }

        public static Assembly[] GetAssembliesToRegister()
        {
            var allAssemblies = new List<Assembly>();

            var name = Assembly.GetExecutingAssembly();

            string filePath = new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath;

            foreach (string dll in Directory.GetFiles(Path.GetDirectoryName(filePath), "*.dll"))
                allAssemblies.Add(Assembly.LoadFile(dll));
            
            return allAssemblies.Where(t=>t.FullName.Contains("Repository")).ToArray();
        }

        public static object Resolve(Type serviceType)
        {
            return Container.Resolve(serviceType);
        }

        public static object IocContainer(Type serviceType)
        {
            return Builder.Build().Resolve(serviceType);
        }       
    }

    [AttributeUsage(AttributeTargets.Class)]
    public class RegisterServiceAttribute : Attribute { }
}
