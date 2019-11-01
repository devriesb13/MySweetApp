using Autodesk.Navisworks.Api.Plugins;
using System.Windows.Forms;
using System.Windows.Forms.Integration;

namespace MySweetApp.Navisworks._2020
{
    [DockPanePlugin(800, 600, FixedSize = false, MinimumHeight = 800, MinimumWidth = 600)]
    [Plugin("MySweetApp", "Sweet", DisplayName = "My Sweet App")]
    public class DockPane_Plugin : DockPanePlugin
    {
        public override Control CreateControlPane()
        {
            var mainview = new Main_View();

            ElementHost element = new ElementHost()
            {
                AutoSize = true,
                Child = mainview
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