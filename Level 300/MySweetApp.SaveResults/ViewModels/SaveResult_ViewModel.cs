using MySweetApp.Core.Contracts;
using MySweetApp.Core.Events;
using MySweetApp.SaveResults.Contracts;
using Prism.Commands;
using Prism.Events;
using Prism.Logging;

namespace MySweetApp.SaveResults.ViewModels
{
    internal class SaveResult_ViewModel
    {
        private IResult currentresult;
        private readonly ILoggerFacade loggerfacade;
        private readonly ISaveResult_Service saveresult_service;

        public SaveResult_ViewModel(IEventAggregator eventAggregator, ILoggerFacade loggerFacade, ISaveResult_Service saveResult_Service)
        {
            eventAggregator.GetEvent<SendResult_Event>().Subscribe(Handler_SendResult_Event);
            loggerfacade = loggerFacade;
            saveresult_service = saveResult_Service;
            SaveResult_Command = new DelegateCommand(Handler_SaveResult_Command);
        }

        private void Handler_SaveResult_Command()
        {
            if (currentresult != null && saveresult_service != null)
            {
                switch (saveresult_service.SaveAsJSON(currentresult))
                {
                    case Core.Enums.ResultTypes.Ok:
                        loggerfacade.Log("save was ok", Category.Info, Priority.Low);
                        break;
                    case Core.Enums.ResultTypes.Failed:
                        loggerfacade.Log("save failed", Category.Info, Priority.Low);
                        break;
                };
            }
        }

        private void Handler_SendResult_Event(IResult result)
        {
            currentresult = result;
            loggerfacade.Log("the result was set in saveresult viewmodel", Category.Info, Priority.Low);
        }

        public DelegateCommand SaveResult_Command { get; }
    }
}