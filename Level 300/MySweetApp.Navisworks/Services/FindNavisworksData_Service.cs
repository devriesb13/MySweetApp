using Autodesk.Navisworks.Api;
using MySweetApp.Core.Contracts;
using MySweetApp.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace MySweetApp.Navisworks.Services
{
    class FindNavisworksData_Service : IFindData_Service
    {
        public FindNavisworksData_Service() { }

        public IResult GetEntities(dynamic obj)
        {
            var returnresult = new Result_Model();

            if (obj is KeyValuePair<string, string> data)
            {
                Search s = new Search();

                s.SearchConditions.Add(SearchCondition.HasCategoryByName(PropertyCategoryNames.Geometry));
                s.SearchConditions.Add(SearchCondition.HasPropertyByName(PropertyCategoryNames.Item, DataPropertyNames.ItemHidden).EqualValue(VariantData.FromBoolean(false)));
                s.SearchConditions.Add(SearchCondition.HasPropertyByName(PropertyCategoryNames.Item, data.Key).EqualValue(VariantData.FromDisplayString(data.Value)));
                s.Selection.SelectAll();
                s.Locations = SearchLocations.DescendantsAndSelf;

                var result = s.FindAll(Application.ActiveDocument, false);
                result.ToList().ForEach(model => returnresult.Payload.Add(model));
            }
            else
            {
                returnresult.ResultType = Core.Enums.ResultTypes.Failed;
            }

            return returnresult;
        }
    }
}