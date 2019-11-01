using Autodesk.Navisworks.Api.Plugins;

namespace MySweetApp.Navisworks
{
    [Plugin("Sweet_MySweetApp", "Sweet")]
    public class EntryPoint_Model : EventWatcherPlugin
    {
        public override void OnLoaded()
        {
            try
            {
                Bootstrapper.Instance.Run();
            }
            catch { }
        }

        public override void OnUnloading()
        {
        }
    }
}