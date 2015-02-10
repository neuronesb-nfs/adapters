//-----------------------------------------------------------------------
// <copyright company="Neudesic LLC" file="ISQSService.cs" >
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
    /// <summary>
    /// Amazon SQS Service Interface
    /// </summary>
    public interface ISQSService
    {
        void SendMessageToSQS(string msgPayload);
        void ReceiveMessageFromSQS(string msgPayload);
    }
}
