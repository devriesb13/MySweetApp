
using MySweetApp.Navisworks.Modules;
using MySweetApp.Core.Application;
using Prism.Modularity;
using Prism.Ioc;
using MySweetApp.Core.Contracts;
using MySweetApp.Navisworks.Services;

#if NAVIS2019 || NAVIS2020
using MySweetApp.SaveResults;
#endif

namespace MySweetApp.Navisworks
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
            moduleCatalog.AddModule<Navisworks_Module>(typeof(Navisworks_Module).FullName);

#if NAVIS2019 || NAVIS2020

            moduleCatalog.AddModule<SaveResult_Module>(typeof(SaveResult_Module).FullName);

#endif
        }

        protected override void RegisterApplicationTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IFindData_Service, FindNavisworksData_Service>();
        }
    }
}