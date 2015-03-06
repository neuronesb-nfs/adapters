//-----------------------------------------------------------------------
// <copyright company="Neudesic LLC" file="SQSSendMessageRS.cs" >
//     Copyright (c) Neudesic LLC. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Amazon.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Quasar.Neuron.Adapters.AmazonSQS
{
    /// <summary>
    /// Amazon SQS Send Message Response Class
    /// </summary>
    public class SQSSendMessageRS
    {
        public string MessageId { get; set; }
        public string RequestId { get; set; }
        public HttpStatusCode HttpStatusCode { get; set; }
        public IDictionary<string, string> Metadata { get; set; }
        public long ContentLength { get; set; }
    }
}
