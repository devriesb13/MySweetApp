using Autodesk.Revit.DB;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace MySweetApp.Revit._2020
{
    internal class Main_ViewModel
    {
        private readonly Document doc;

        public Main_ViewModel(Document document)
        {
            doc = document;
            SelectionTypes = new ObservableCollection<string>() { "Walls", "Floors" };
            FindSelection_Command = new RelayCommand(p => Handler_FindSelection_Command(p));
            Results = new ObservableCollection<Element>();
        }

        public ICommand FindSelection_Command { get; }

        public ObservableCollection<string> SelectionTypes { get; }

        public ObservableCollection<Element> Results { get; }

        private void GetElements (Type type)
        {
            FilteredElementCollector allelements = new FilteredElementCollector(doc).OfClass(type);
            Results.Clear();
            allelements.ToList().ForEach(element => Results.Add(element));

            var ben = new ElementId(0) { };
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
                    case "Walls":
                        GetElements(typeof(Wall));
                        break;

                    case "Floors":
                        GetElements(typeof(Floor));
                        break;
                }
            }
        }
    }
} 