using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Prism.Ioc;
using Prism.Services.Dialogs;
using System.Windows;

namespace MySweetApp.Revit.Commands
{
    [Transaction(TransactionMode.ReadOnly)]
    public class DockPane_Commands : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            ((IContainerRegistry)Bootstrapper.Instance.Container).RegisterInstance(commandData.Application.ActiveUIDocument.Document);

            var window = new Window
            {
                Content = Bootstrapper.Instance.MainView,
                Title = Core.Constants.AppData.DISPLAYAPPNAME
                
            };

            window.Show();

            return Result.Succeeded;
        }
    }
}