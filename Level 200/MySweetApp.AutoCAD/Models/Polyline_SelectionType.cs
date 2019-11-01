using MySweetApp.Core.Contracts;
using AADS = Autodesk.AutoCAD.DatabaseServices;

namespace MySweetApp.AutoCAD.Models
{
    internal class Polyline_SelectionType : SelectionTypeBase
    {
        public Polyline_SelectionType() : base("Polylines") { }

        public override IResult Find()
        {
            return GetEntities(typeof(AADS.Polyline));
        }
    }
}