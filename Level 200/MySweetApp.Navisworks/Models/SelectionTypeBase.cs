using Autodesk.Navisworks.Api;
using MySweetApp.Core.Contracts;
using MySweetApp.Core.Models;
using System;
using System.Linq;

namespace MySweetApp.Navisworks.Models
{
    abstract class SelectionTypeBase : ISelectionType
    {
        public SelectionTypeBase(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public abstract IResult Find();

        public IResult GetEntities(string type, string dataPropertyNames)
        {
            var returnresult = new Result_Model();

            Search s = new Search();

            s.SearchConditions.Add(SearchCondition.HasCategoryByName(PropertyCategoryNames.Geometry));
            s.SearchConditions.Add(SearchCondition.HasPropertyByName(PropertyCategoryNames.Item, DataPropertyNames.ItemHidden).EqualValue(VariantData.FromBoolean(false)));
            s.SearchConditions.Add(SearchCondition.HasPropertyByName(PropertyCategoryNames.Item, dataPropertyNames).EqualValue(VariantData.FromDisplayString(type)));
            s.Selection.SelectAll();
            s.Locations = SearchLocations.DescendantsAndSelf;

            var result = s.FindAll(Application.ActiveDocument, false);
            result.ToList().ForEach(model => returnresult.Payload.Add(model));

            return returnresult;
        }

    }
}