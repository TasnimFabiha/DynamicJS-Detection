using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace xssiServer.Models
{
    [Table("ScriptHolder")]
    public class ScriptHolder
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Source { get; set; }
        public string Content { get; set; }
    }
}