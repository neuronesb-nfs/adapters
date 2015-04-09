//-----------------------------------------------------------------------
// <copyright company="Neudesic LLC" file="AmazonSQSTransientErrorDetectionStrategy.cs" >
//     Copyright (c) Neudesic LLC. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Microsoft.Practices.TransientFaultHandling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quasar.Neuron.Adapters.AmazonSQS
{
    public class AmazonSQSTransientErrorDetectionStrategy : ITransientErrorDetectionStrategy
    {
        public bool IsTransient(Exception exception)
        {
            //Get the exception type
            string exceptionType = exception.GetType().Name.Trim();
            switch (exceptionType)
            {
                case AmazonSQSExceptionTypes.TimeoutException:
                case AmazonSQSExceptionTypes.WebException:
                case AmazonSQSExceptionTypes.CommunicationException:
                case AmazonSQSExceptionTypes.SocketException:
                case AmazonSQSExceptionTypes.ServerTooBusyException:
                case AmazonSQSExceptionTypes.UnauthorizedAccessException:
                case AmazonSQSExceptionTypes.SecurityTokenException:
                case AmazonSQSExceptionTypes.ServerErrorException:
                case AmazonSQSExceptionTypes.ProtocolException:
                case AmazonSQSExceptionTypes.FaultException:
                case AmazonSQSExceptionTypes.EndpointNotFoundException:
                case AmazonSQSExceptionTypes.CommunicationObjectFaultedException:
                case AmazonSQSExceptionTypes.SqlException:
                case AmazonSQSExceptionTypes.MessagingException:
                    return true;
                default:
                    break;
            }
            return false;
        }
    }
}
