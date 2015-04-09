//-----------------------------------------------------------------------
// <copyright company="Neudesic LLC" file="AmazonSQSExceptionTypes.cs" >
//     Copyright (c) Neudesic LLC. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quasar.Neuron.Adapters.AmazonSQS
{
    public class AmazonSQSExceptionTypes
    {
        public const string TimeoutException = "TimeoutException";
        public const string WebException = "WebException";
        public const string CommunicationException = "CommunicationException";
        public const string SocketException = "SocketException";
        public const string ServerTooBusyException = "ServerTooBusyException";
        public const string UnauthorizedAccessException = "UnauthorizedAccessException";
        public const string SecurityTokenException = "SecurityTokenException";
        public const string ServerErrorException = "ServerErrorException";
        public const string ProtocolException = "ProtocolException";
        public const string FaultException = "FaultException";
        public const string EndpointNotFoundException = "EndpointNotFoundException";
        public const string CommunicationObjectFaultedException = "CommunicationObjectFaultedException";
        public const string SqlException = "SqlException";
        public const string MessagingException = "MessagingException";
    }
}
