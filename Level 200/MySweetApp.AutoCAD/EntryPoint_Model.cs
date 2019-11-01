using MySweetApp.AutoCAD.Commands;
using System;
using System.Drawing;
using AAR = Autodesk.AutoCAD.Runtime;
using AAW = Autodesk.AutoCAD.Windows;

namespace MySweetApp.AutoCAD
{
    public class EntryPoint_Model : AAR.IExtensionApplication
    {
        public static AAW.PaletteSet PaletteSet = null;

        public void Initialize()
        {
            if (PaletteSet is null)
            {
                PaletteSet = new AAW.PaletteSet("My Sweet App", Commands_Model.PALETTESET_COMMAND, new Guid("4d55ea36-b620-452b-8128-94147a934112"))
                {
                    MinimumSize = new Size(350, 350)
                };

                PaletteSet.AddVisual("General", new Main_View());
            }
        }

        public void Terminate()
        {
        }
    }
}