using System;
using System.Collections.Generic;
using System.Text;
using AAR = Autodesk.AutoCAD.Runtime;

namespace MySweetApp.AutoCAD.Commands
{
   public class Commands_Model
    {
        public const string PALETTESET_COMMAND = "MYSweetAPP";

        [AAR.CommandMethod(PALETTESET_COMMAND)]
        public void MySweetApp()
        {
           EntryPoint_Model.PaletteSet.Visible = true;
        }
    }
}
