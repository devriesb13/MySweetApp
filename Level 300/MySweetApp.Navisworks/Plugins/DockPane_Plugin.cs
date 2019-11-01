using Autodesk.Navisworks.Api.Plugins;
using System.Windows.Forms;
using System.Windows.Forms.Integration;

namespace MySweetApp.Navisworks.Plugins
{
    [DockPanePlugin(800, 600, FixedSize = false, MinimumHeight = 800, MinimumWidth = 600)]
    [Plugin(Core.Constants.AppData.APPNAME, "Sweet", DisplayName = Core.Constants.AppData.DISPLAYAPPNAME)]
    public class DockPane_Plugin : DockPanePlugin
    {
        public override Control CreateControlPane()
        {
            ElementHost element = new ElementHost()
            {
                AutoSize = true,
                Child = Bootstrapper.Instance.MainView
            };

            element.CreateControl();

            return element;
        }

        public override void DestroyControlPane(Control pane)
        {
            pane?.Dispose();
        }
    }
}