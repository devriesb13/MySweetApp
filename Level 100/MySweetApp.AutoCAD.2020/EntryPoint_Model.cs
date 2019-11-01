using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using AAR = Autodesk.AutoCAD.Runtime;
using AAW = Autodesk.AutoCAD.Windows;

namespace MySweetApp.AutoCAD._2020
{
    public class EntryPoint_Model
    {
        AAW.PaletteSet paletteset = null;

        [AAR.CommandMethod("MySweetApp")]
        public void MySweetApp()
        {
            if (paletteset is null)
            {
                paletteset = new AAW.PaletteSet("My Sweet App", "MySweetApp", new Guid("4d55ea36-b620-452b-8128-94147a934112"))
                {
                    MinimumSize = new Size(350, 350)
                };

                paletteset.AddVisual("General", new Main_View());
            }

            paletteset.Visible = true;
  
        }

    }
}
