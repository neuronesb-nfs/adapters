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
        public SQSSendMessageRS SendMessageToSQS(SQSSendMessageRQ sqsSendMessage)
        {
            using (IAmazonSQS amazonSQSClient = GetAmazonSQSClient(sqsSendMessage.ServiceURL, sqsSendMessage.AccessKey, sqsSendMessage.SecretAccessKey))
            {
                //// Sending a message : Create and initialize a SendMessageRequest instance. Specify the queue name and the message to send,
                var sendMessageRequest = new SendMessageRequest
                {
                    QueueUrl = sqsSendMessage.EgressQueueUrl,
                    MessageBody = sqsSendMessage.MessagePayload
                };
                ////amazonSQSClient.SendMessage(sendMessageRequest);
                var sendMessageResponse = amazonSQSClient.SendMessage(sendMessageRequest);

                //// Return the response from Amazon SQS
                return new SQSSendMessageRS()
                {
                    MessageId = sendMessageResponse.MessageId,
                    RequestId = sendMessageResponse.ResponseMetadata.RequestId,
                    HttpStatusCode = sendMessageResponse.HttpStatusCode,
                    Metadata = sendMessageResponse.ResponseMetadata.Metadata,
                    ContentLength = sendMessageResponse.ContentLength
                };
            }
        }

        public SQSReceiveMessageRS ReceiveMessageFromSQS(SQSReceiveMessageRQ sqsReceiveMessage)
        {
            //// Initialize the response object
            var sqsReceiveMessageRS = new SQSReceiveMessageRS() { SQSMessages = new List<SQSMessage>() };

            using (IAmazonSQS amazonSQSClient = GetAmazonSQSClient(sqsReceiveMessage.ServiceURL, sqsReceiveMessage.AccessKey, sqsReceiveMessage.SecretAccessKey))
            {
                //// Receiving a message from SQS
                var receiveMessageRequest = new ReceiveMessageRequest { QueueUrl = sqsReceiveMessage.IngressQueueUrl };
                var receiveMessageResponse = amazonSQSClient.ReceiveMessage(receiveMessageRequest);
                
                if (receiveMessageResponse.Messages != null)
                {
                    receiveMessageResponse.Messages.ForEach(message =>
                    {
                        var sqsMessage = new SQSMessage() { MessageId = message.MessageId, Body = message.Body };
                        sqsReceiveMessageRS.SQSMessages.Add(sqsMessage);

                        //// Delete a message from SQS
                        var deleteRequest = new DeleteMessageRequest { QueueUrl = sqsReceiveMessage.IngressQueueUrl, ReceiptHandle = message.ReceiptHandle };
                        amazonSQSClient.DeleteMessage(deleteRequest);
                    });
                }
            }
            
            //// Return the response
            return sqsReceiveMessageRS;
        }

        /// <summary>
        /// Get Amazon SQS Client Instance
        /// </summary>
        /// <param name="serviceURL">serviceURL</param>
        /// <param name="accessKey">accessKey</param>
        /// <param name="secretAccessKey">secretAccessKey</param>
        /// <returns>IAmazonSQS</returns>
        private IAmazonSQS GetAmazonSQSClient(string serviceURL, string accessKey, string secretAccessKey)
        {
            //// Create and initialize an AmazonSQSConfig instance, and set the ServiceURL property with the protocol and service endpoint
            var amazonSQSConfig = new AmazonSQSConfig();
            amazonSQSConfig.ServiceURL = serviceURL;

            //// Use the AmazonSQSConfig instance to create and initialize an AmazonSQSClient instance
            var sqsClient = AWSClientFactory.CreateAmazonSQSClient(accessKey, secretAccessKey, amazonSQSConfig);

            //// Return Amazon SQS Client
            return sqsClient;
        }
    }
}
