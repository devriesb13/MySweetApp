using MySweetApp.Core.Attributes;
using MySweetApp.Core.Contracts;
using MySweetApp.Core.Models;
using AADS = Autodesk.AutoCAD.DatabaseServices;

namespace MySweetApp.AutoCAD.Models
{
    [DataTemplate("Circles_Resources.xaml")]
    internal class Circle_SelectionType : SelectionTypeBase
    {
        public Circle_SelectionType(IFindData_Service data_Service) : base("Circles", data_Service) { }

        public override IResult Find()
        {
            return FindData_Service.GetEntities(typeof(AADS.Circle));
        }
    }
}