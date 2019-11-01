using Prism.Regions;

namespace MySweetApp.Core.Contracts
{
    public interface IRegionManagerAware
    {
        IRegionManager RegionManager { get; }
    }
}