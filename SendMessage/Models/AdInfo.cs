using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SMSSending.Models
{
    public class AdInfo
    {
        [Key]
        public int Id { get; set; }
        public int IdPhone { get; set; }
        public string AddInfo { get; set; }

        [ForeignKey("Id")]
        public Phone phone { get; set; }
    }
}