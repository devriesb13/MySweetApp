using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Windows;

namespace MySweetApp.Revit.Commands
{
    [Transaction(TransactionMode.ReadOnly)]
    public class DockPane_Commands : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            var view = new Main_View(commandData.Application.ActiveUIDocument.Document);

            var window = new Window
            {
                Content = view,
                Title= "My Sweet App"
            };

            window.Show();

            return Result.Succeeded;
        }
    }
}