using MySweetApp.Core.Contracts;
using MySweetApp.Core.Events;
using MySweetApp.Core.Models;
using Prism.Commands;
using Prism.Events;
using Prism.Logging;
using System;
using System.Collections.ObjectModel;

namespace MySweetApp.Core.ViewModels
{
    internal class Contents_ViewModel
    {
        private readonly SendResult_Event sendresult_event;
        private readonly Logger loggerfacade;

        public Contents_ViewModel(IEventAggregator eventAggregator, ILoggerFacade loggerFacade, ISelectionType[] selectionTypes)
        {
            sendresult_event= eventAggregator.GetEvent<SendResult_Event>();
            loggerfacade = loggerFacade as Logger;
            SelectionTypes = new ObservableCollection<ISelectionType>(selectionTypes);
            FindSelection_Command = new DelegateCommand<ISelectionType>(Handler_FindSelection_Command);
        }

        private void Handler_FindSelection_Command(ISelectionType payload)
        {
            if (payload is null) throw new ArgumentNullException(nameof(payload));

            var result = payload.Find();

            if (result.ResultType == Core.Enums.ResultTypes.Ok)
            {
                sendresult_event.Publish(result);
                loggerfacade.Log("Result was sent", Category.Info, Priority.Medium);
            }    
            else
            {
                loggerfacade.Log("The return result failed", Category.Warn, Priority.High);
            }
            
        }

        public ObservableCollection<ISelectionType> SelectionTypes { get; }

        public DelegateCommand<ISelectionType> FindSelection_Command { get; }
    }
}