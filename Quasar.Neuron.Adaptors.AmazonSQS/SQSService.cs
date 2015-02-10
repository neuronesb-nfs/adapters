//-----------------------------------------------------------------------
// <copyright company="Neudesic LLC" file="SQSService.cs" >
//     Copyright (c) Neudesic LLC. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quasar.Neuron.Adaptors.AmazonSQS
{
    /// <summary>
    /// Subscription adapters are responsible for publishing messages from Neuron to an external system
    /// </summary>
    public class SQSService : ISQSService
    {

        public void SendMessageToSQS(string msgPayload)
        {
            System.Diagnostics.EventLog.WriteEntry("Application", msgPayload);
        }

        public void ReceiveMessageFromSQS(string msgPayload)
        {
            throw new NotImplementedException();
        }
    }
}
