using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace xssiServer.Models
{
    [Table("GenericScriptHolder")]
    public class GenericScriptHolder
    {
        [Key]
        public int Id { get; set; }
        public int Number { get; set; }
        public string Source { get; set; }
        public string Content { get; set; }
        
    }
}