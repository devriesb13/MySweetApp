using Autodesk.Navisworks.Api;
using MySweetApp.Core.Contracts;
using MySweetApp.Core.Models;
using System.Collections.Generic;

namespace MySweetApp.Navisworks.Models
{
    internal class Wall_SelectionType : SelectionTypeBase
    {
        public Wall_SelectionType(IFindData_Service findData_Service) : base("Revit Walls", findData_Service) { }

        public override IResult Find()
        {
            return FindData_Service.GetEntities(new KeyValuePair<string, string>(DataPropertyNames.ItemName, "Basic Wall"));
        }
    }
}