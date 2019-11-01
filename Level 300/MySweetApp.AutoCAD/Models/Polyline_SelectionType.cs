using MySweetApp.Core.Attributes;
using MySweetApp.Core.Contracts;
using MySweetApp.Core.Models;
using AADS = Autodesk.AutoCAD.DatabaseServices;

namespace MySweetApp.AutoCAD.Models
{
    [DataTemplate("Polylines_Resources.xaml")]
    internal class Polyline_SelectionType : SelectionTypeBase
    {
        public Polyline_SelectionType(IFindData_Service data_Service) : base("Polylines", data_Service) { }

        public override IResult Find()
        {
            return FindData_Service.GetEntities(typeof(AADS.Polyline));
        }
    }
}