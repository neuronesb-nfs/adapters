//-----------------------------------------------------------------------
// <copyright company="Neudesic LLC" file="SQSReceiveMessageRS.cs" >
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
    public class SQSReceiveMessageRS
    {
        public List<SQSMessage> SQSMessages { get; set; }

    }

    public class SQSMessage
    {
        public string Body { get; set; }
        public string MessageId { get; set; }
        //public string ReceiptHandle { get; set; }
    }
}
