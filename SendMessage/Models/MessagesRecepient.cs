using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSSending
{
    public class MessageResepient
    {
        [Key]
        public int Id { get; set; }
        public int RecepientId { get; set; }
        public int MessageId { get; set; }
        public DateTime DateTimeCreate { get; set; }
        public DateTime DateTimeStart { get; set; }
        public DateTime DateTimeEnd { get; set; }
        public int Period { get; set; }

      
        [ForeignKey("MessageId")]
        public Message Message { get; set; }
    }
}
