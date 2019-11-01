using MySweetApp.Core.Contracts;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace MySweetApp.Core.Models
{
    public abstract class ModuleBase : IModule, IRegionManagerAware
    {
        public ModuleBase(IRegionManager regionManager)
        {
            RegionManager = regionManager;
        }

        public IRegionManager RegionManager { get; }

        public abstract void OnInitialized(IContainerProvider containerProvider);

        public abstract void RegisterTypes(IContainerRegistry containerRegistry);
    }
}