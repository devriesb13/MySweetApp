using MySweetApp.Core.Application;
using MySweetApp.Core.Contracts;
using MySweetApp.Revit.Services;
using MySweetApp.Revit.Modules;
using Prism.Ioc;
using Prism.Modularity;

#if REVIT2019 || REVIT2020
using MySweetApp.SaveResults;
#endif

namespace MySweetApp.Revit
{
    internal sealed class Bootstrapper : MySweetApplication
    {
        private static readonly object _synclock = new object();

        private static volatile Bootstrapper _instance;

        public static Bootstrapper Instance
        {
            get
            {
                if (_instance != null) return _instance;

                lock (_synclock)
                {
                    {
                        if (_instance == null) _instance = new Bootstrapper();
                    }
                }
                return _instance;
            }
        }

        protected override void ConfigureApplicationModules(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<Revit_Module>(typeof(Revit_Module).FullName);

#if REVIT2019 || REVIT2020

                    moduleCatalog.AddModule<SaveResult_Module>(typeof(SaveResult_Module).FullName);

#endif
        }

        protected override void RegisterApplicationTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IFindData_Service, FindRevitData_Service>();
        }
    }
}