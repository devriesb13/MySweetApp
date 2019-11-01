using Autodesk.Revit.DB;
using MySweetApp.Core.Commands;
using MySweetApp.Core.Contracts;
using MySweetApp.Revit.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace MySweetApp.Revit.ViewModels
{
    internal class Main_ViewModel
    {
        private readonly Document doc;

        public Main_ViewModel(Document document)
        {
            doc = document;

            SelectionTypes = new ObservableCollection<ISelectionType>() { new Floor_SelectionType(document), new Wall_SelectionType(document)};

            FindSelection_Command = new RelayCommand(p => Handler_FindSelection_Command(p));

            Results = new ObservableCollection<object>();
        }

        public ICommand FindSelection_Command { get; }

        public ObservableCollection<ISelectionType> SelectionTypes { get; }

        public ObservableCollection<object> Results { get; }

        private void Handler_FindSelection_Command(object param)
        {
            if (param is null)
            {
                throw new ArgumentNullException(nameof(param));
            }

            if (param is ISelectionType mytype)
            {
                var result = mytype.Find();

                if (result.ResultType == Core.Enums.ResultTypes.Ok)
                {
                    Results.Clear();
                    result.Payload.ForEach(obj => Results.Add(obj));
                }
            }
        }
    }
}