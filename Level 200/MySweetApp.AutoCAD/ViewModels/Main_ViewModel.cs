using MySweetApp.AutoCAD.Models;
using MySweetApp.Core.Commands;
using MySweetApp.Core.Contracts;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MySweetApp.AutoCAD.ViewModels
{
    internal class Main_ViewModel
    {
        public Main_ViewModel()
        {
            SelectionTypes = new ObservableCollection<ISelectionType>() { new Line_SelectionType() };

#if ACAD2018

            SelectionTypes.Add(new Circle_SelectionType());

#elif ACAD2019

            SelectionTypes.Add(new Circle_SelectionType());
            SelectionTypes.Add(new Polyline_SelectionType());

#elif ACAD2020

            SelectionTypes.Add(new Polyline_SelectionType());

#endif

            FindSelection_Command = new RelayCommand(p => Handler_FindType_Execute(p));
            Results = new ObservableCollection<object>();
        }

        public ICommand FindSelection_Command { get; }

        public ObservableCollection<ISelectionType> SelectionTypes { get; }

        public ObservableCollection<object> Results { get; }

        private void Handler_FindType_Execute(object param)
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