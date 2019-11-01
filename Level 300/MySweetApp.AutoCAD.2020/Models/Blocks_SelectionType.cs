using MySweetApp.Core.Attributes;
using MySweetApp.Core.Contracts;
using MySweetApp.Core.Models;
using AADS = Autodesk.AutoCAD.DatabaseServices;

namespace MySweetApp.AutoCAD.Models
{
    [DataTemplate("Blocks_Resources.xaml")]
    internal class Blocks_SelectionType : SelectionTypeBase
    {
        public Blocks_SelectionType(IFindData_Service data_Service) : base("Blocks", data_Service)
        {
        }

        public override IResult Find()
        {
            return FindData_Service.GetEntities(typeof(AADS.BlockReference));
        }
    }
}