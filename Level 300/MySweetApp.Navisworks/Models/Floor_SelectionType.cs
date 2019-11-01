using Autodesk.Navisworks.Api;
using MySweetApp.Core.Contracts;
using MySweetApp.Core.Models;
using System.Collections.Generic;

namespace MySweetApp.Navisworks.Models
{
    internal class Floor_SelectionType : SelectionTypeBase
    {
        public Floor_SelectionType(IFindData_Service findData_Service) : base("Revit Floors", findData_Service) { }

        public override IResult Find()
        {
            return FindData_Service.GetEntities(new KeyValuePair<string, string>(DataPropertyNames.ItemName, "Floor"));
        }
    }
}