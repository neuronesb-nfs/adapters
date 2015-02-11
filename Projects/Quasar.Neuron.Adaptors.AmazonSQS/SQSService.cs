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

        public void SendMessageToSQS(string msgPayload)
        {
            System.Diagnostics.EventLog.WriteEntry("Application", msgPayload);

            string accessKey = "AKIAIF5XX6JILIB3QSNA";
            string secretAccessKey = "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";
            var amazonSQSConfig = new AmazonSQSConfig();
            amazonSQSConfig.ServiceURL = "http://sqs.us-west-2.amazonaws.com";
            var sqs = AWSClientFactory.CreateAmazonSQSClient(accessKey, secretAccessKey, amazonSQSConfig);

            string queueUrl = "https://sqs.us-west-2.amazonaws.com/389642382467/neuron_sqs_test";

            //Sending a message
            var sendMessageRequest = new SendMessageRequest
            {
                QueueUrl = queueUrl,
                MessageBody = msgPayload
            };
            sqs.SendMessage(sendMessageRequest);
        }

        public void ReceiveMessageFromSQS(string msgPayload)
        {
            throw new NotImplementedException();
        }
    }
}
