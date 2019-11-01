using Autodesk.Navisworks.Api;
using MySweetApp.Core.Contracts;
using MySweetApp.Core.Models;
using System.Collections.Generic;

namespace MySweetApp.Navisworks.Models
{
    internal class Line_SelectionType : SelectionTypeBase
    {
        public Line_SelectionType(IFindData_Service findData_Service) : base("AutoCAD Lines", findData_Service) { }

        public override IResult Find()
        {
            return FindData_Service.GetEntities(new KeyValuePair<string,string>(DataPropertyNames.ItemType, "Line Set"));
        }
    }
}