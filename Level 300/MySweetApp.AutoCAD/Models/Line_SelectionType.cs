using MySweetApp.Core.Attributes;
using MySweetApp.Core.Contracts;
using MySweetApp.Core.Models;
using AADS = Autodesk.AutoCAD.DatabaseServices;

namespace MySweetApp.AutoCAD.Models
{
    [DataTemplate("Lines_Resources.xaml")]
    internal class Line_SelectionType : SelectionTypeBase
    {
        public Line_SelectionType(IFindData_Service data_Service) : base("Lines", data_Service) { }

        public override IResult Find()
        {
            return FindData_Service.GetEntities(typeof(AADS.Line));
        }
    }
}