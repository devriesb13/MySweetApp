using MySweetApp.Core.Contracts;
using MySweetApp.Core.Events;
using Prism.Events;
using System.Collections.ObjectModel;

namespace MySweetApp.AutoCAD.ViewModels
{
    class Results_ViewModel
    {
        public Results_ViewModel(IEventAggregator eventAggregator)
        {
            eventAggregator.GetEvent<SendResult_Event>().Subscribe(Handler_SendResult_Event);
            Results = new ObservableCollection<object>();
        }

        public ObservableCollection<object> Results { get; }

        private void Handler_SendResult_Event(IResult result)
        {
            Results.Clear();
            Results.AddRange(result.Payload);
        }
    }
}