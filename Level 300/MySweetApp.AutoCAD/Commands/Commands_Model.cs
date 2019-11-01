using MySweetApp.AutoCAD.Modules;
using MySweetApp.Core.Constants;
using System;
using System.Collections.Generic;
using System.Text;
using AAR = Autodesk.AutoCAD.Runtime;

namespace MySweetApp.AutoCAD.Commands
{
    public class Commands_Model
    {
        [AAR.CommandMethod(AppData.APPNAME)]
        public void ShowPaletteSet()
        {
            AutoCAD_Module.PaletteSet.Visible = true;
        }
    }
}
