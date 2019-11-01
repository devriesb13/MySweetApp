using Autodesk.Navisworks.Api;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace MySweetApp.Navisworks._2020
{
    internal class Main_ViewModel
    {
        public Main_ViewModel()
        {
            SelectionTypes = new ObservableCollection<string>() { "AutoCAD Circles", "AutoCAD Lines", "Revit Walls", "Revit Floors" };
            FindSelection_Command = new RelayCommand(p => Handler_FindSelection_Command(p));
            Results = new ObservableCollection<ModelItem>();
        }

        public ICommand FindSelection_Command { get; }

        public ObservableCollection<string> SelectionTypes { get; }

        public ObservableCollection<ModelItem> Results { get; }

        internal void GetEntities(string type, string dataPropertyNames)
        {
            Search s = new Search();

            s.SearchConditions.Add(SearchCondition.HasCategoryByName(PropertyCategoryNames.Geometry));
            s.SearchConditions.Add(SearchCondition.HasPropertyByName(PropertyCategoryNames.Item, DataPropertyNames.ItemHidden).EqualValue(VariantData.FromBoolean(false)));
            s.SearchConditions.Add(SearchCondition.HasPropertyByName(PropertyCategoryNames.Item, dataPropertyNames).EqualValue(VariantData.FromDisplayString(type)));
            s.Selection.SelectAll();
            s.Locations = SearchLocations.DescendantsAndSelf;

           var result= s.FindAll(Application.ActiveDocument, false);

            Results.Clear();
            result.ToList().ForEach(model => Results.Add(model));
        }

        private void Handler_FindSelection_Command(object param)
        {
            if (param is null)
            {
                throw new ArgumentNullException(nameof(param));
            }

            if (param is string)
            {  
                switch (param)
                {
                    case "AutoCAD Circles":
                        GetEntities("Circle", DataPropertyNames.ItemType);
                        break;

                    case "AutoCAD Lines":
                        GetEntities("Line Set", DataPropertyNames.ItemType);
                        break;

                    case "Revit Walls":
                        GetEntities("Basic Wall", DataPropertyNames.ItemName);
                        break;

                    case "Revit Floors":
                        GetEntities("Floor", DataPropertyNames.ItemName);
                        break;
                }
            }
        }
    }
}