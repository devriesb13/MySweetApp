using MySweetApp.Core.Commands;
using MySweetApp.Core.Contracts;
using MySweetApp.Navisworks.Models;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MySweetApp.Navisworks.ViewModels
{
    internal class Main_ViewModel
    {
        public Main_ViewModel()
        {
            SelectionTypes = new ObservableCollection<ISelectionType>() { new Line_SelectionType() };

#if NAVIS2019

            SelectionTypes.Add(new Circle_SelectionType());

#elif NAVIS2020

            SelectionTypes.Add(new Wall_SelectionType());
            SelectionTypes.Add(new Floor_SelectionType());

#endif

            FindSelection_Command = new RelayCommand(p => Handler_FindSelection_Command(p));
            Results = new ObservableCollection<object>();
        }

        public ICommand FindSelection_Command { get; }

        public ObservableCollection<ISelectionType> SelectionTypes { get; }

        public ObservableCollection<object> Results { get; }

        private void Handler_FindSelection_Command(object param)
        {
            if (param is null) throw new ArgumentNullException(nameof(param));

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