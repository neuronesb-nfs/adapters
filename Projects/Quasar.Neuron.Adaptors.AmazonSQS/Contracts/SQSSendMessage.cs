//-----------------------------------------------------------------------
// <copyright company="Neudesic LLC" file="SQSSendMessage.cs" >
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
    /// Amazon SQS Send Message Class
    /// </summary>
    public class SQSSendMessage
    {
        /// <summary>
        /// Amazon SQS Access Key
        /// </summary>
        public string AccessKey { get; set; }
        /// <summary>
        /// Amazon SQS Secret Access Key
        /// </summary>
        public string SecretAccessKey { get; set; }
        /// <summary>
        /// The AWS SDK for .NET uses US East (N.Virginia) Region as the default region if you do not
        /// specify region in your code. However, the AWS Management Console uses US West (Oregon) Region
        /// as its default. Therefore, when using the AWS Management Console in conjunction with your 
        /// development, be sure to specify the same region in both your code and the console.
        /// </summary>
        public string ServiceURL { get; set; }
        /// <summary>
        /// Require the queue URL to send, receive, and delete queue messages. A queue URL is constructed
        /// in the following format: https://queue.amazonaws.com/YOUR_ACCOUNT_NUMBER/YOUR_QUEUE_NAME
        /// </summary>
        public string QueueUrl { get; set; }
        /// <summary>
        /// Message Payload
        /// </summary>
        public string MessagePayload { get; set; }
    }
}
