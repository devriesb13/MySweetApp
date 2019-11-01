using MySweetApp.Core.Contracts;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySweetApp.Core.Events
{
    public class SendResult_Event : PubSubEvent<IResult> { }
}
