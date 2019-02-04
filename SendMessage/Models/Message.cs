using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace SMSSending
{
    [DataContract]
    [Serializable]
    public class Message
    {
        [Key]
        [DataMember]
        public int MessageId { get; set; }
        [DataMember]
        public int UserId { get; set; }
      
        [DataMember]
        public string TextOfMessage { get; set; }

        [ForeignKey("UserId")]
        public User Sender { get; set; }
        public ICollection<MessageResepient> MessageResepients { get; set; }

        public Message()
        {
            MessageResepients = new List<MessageResepient>();
        }
    }
}
