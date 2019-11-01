using MySweetApp.Core.Prism;
using MySweetApp.Core.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using System;
using System.Reflection;
using System.Windows.Controls;

namespace MySweetApp.Core.Application
{
    public abstract class MySweetApplication : PrismApplication
    {
        public void Run()
        {
            InitializeInternal();
        }

        protected virtual void ConfigureApplicationModules(IModuleCatalog moduleCatalog)
        {
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            ConfigureApplicationModules(moduleCatalog);
        }

        protected override void ConfigureViewModelLocator()
        {
            base.ConfigureViewModelLocator();

            ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver((viewType) =>
            {
                var viewName = viewType.FullName;
                var viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName;
                var viewModelName = $"{viewName.Replace(".Views.", ".ViewModels.")}Model, {viewAssemblyName}";
                return Type.GetType(viewModelName);
            });
        }

        protected override UserControl CreateShell()
        {
            return Container.Resolve<Shell_View>();
        }

        protected virtual void RegisterApplicationTypes(IContainerRegistry containerRegistry)
        {
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //put some stuff in here to load into all products
            RegisterApplicationTypes(containerRegistry);
        }
    }
}