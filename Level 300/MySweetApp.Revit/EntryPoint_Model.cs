using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace MySweetApp.Revit
{
    class EntryPoint_Model : IExternalApplication
    {
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

        public Result OnStartup(UIControlledApplication application)
        {
            try
            {
                Bootstrapper.Instance.Run();
            }
            catch { }

            return Result.Succeeded;
        }
    }
}
