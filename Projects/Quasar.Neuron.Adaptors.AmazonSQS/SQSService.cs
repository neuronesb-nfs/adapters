//-----------------------------------------------------------------------
// <copyright company="Neudesic LLC" file="SQSService.cs" >
//     Copyright (c) Neudesic LLC. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Amazon;
using Amazon.SQS;
using Amazon.SQS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quasar.Neuron.Adapters.AmazonSQS
{
    /// <summary>
    /// Subscription adapters are responsible for publishing messages from Neuron to an external system
    /// </summary>
    public class SQSService : ISQSService
    {
        /// <summary>
        /// Send messgae to Amazon SQS Queue
        /// </summary>
        /// <param name="sqsSendMessage"></param>
        public void SendMessageToSQS(SQSSendMessage sqsSendMessage)
        {

            ////Create and initialize an AmazonSQSConfig instance, and set the ServiceURL property with the protocol and service endpoint
            var amazonSQSConfig = new AmazonSQSConfig();
            amazonSQSConfig.ServiceURL = sqsSendMessage.ServiceURL;

            ////Use the AmazonSQSConfig instance to create and initialize an AmazonSQSClient instance
            var sqs = AWSClientFactory.CreateAmazonSQSClient(sqsSendMessage.AccessKey, sqsSendMessage.SecretAccessKey, amazonSQSConfig);

            ////Sending a message : Create and initialize a SendMessageRequest instance. Specify the queue name and the message to send,
            var sendMessageRequest = new SendMessageRequest
            {
                QueueUrl = sqsSendMessage.QueueUrl,
                MessageBody = sqsSendMessage.MessagePayload
            };
            sqs.SendMessage(sendMessageRequest);
            ////var sendMessageResponse = sqs.SendMessage(sendMessageRequest);        }

        public void ReceiveMessageFromSQS(SQSReceiveMessage sqsReceiveMessage)
        {
            throw new NotImplementedException();
        }
    }
}
