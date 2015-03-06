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
        /// <summary>
        /// Send message to Amazon SQS (Publish)
        /// </summary>
        /// <param name="sqsSendMessage">SQSSendMessage</param>
        SQSSendMessageRS SendMessageToSQS(SQSSendMessageRQ sqsSendMessage);

        /// <summary>
        /// Receive message from Amazon SQS (Subscribe)
        /// </summary>
        /// <param name="sqsReceiveMessage"></param>
        SQSReceiveMessageRS ReceiveMessageFromSQS(SQSReceiveMessageRQ sqsReceiveMessage);

    }
}
