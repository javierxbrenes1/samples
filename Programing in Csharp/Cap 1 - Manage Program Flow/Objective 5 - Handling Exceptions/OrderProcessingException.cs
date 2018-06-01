using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Programing_in_Csharp
{
    [Serializable] //your custom exception has to be serialized
    class OrderProcessingException : Exception, ISerializable
    {

        public int OrderId { get; private set; }

        public OrderProcessingException(int orderId)
        {
            this.HelpLink = "mywebsite.com/info";
            this.OrderId = orderId;
        }

        public OrderProcessingException(int orderId, string message) : base(message)
        {
            this.HelpLink = "mywebsite.com/info";
            this.OrderId = orderId;
        }

        public OrderProcessingException(int orderId, string message, Exception exception): base(message, exception)
        {
            this.HelpLink = "mywebsite.com/info";
            this.OrderId = orderId;
        }

        protected OrderProcessingException(SerializationInfo info, StreamingContext context)
        {
            this.OrderId = (int)info.GetValue("OrderId", typeof(int));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("OrderId", OrderId, typeof(int));
        }
    }
}
