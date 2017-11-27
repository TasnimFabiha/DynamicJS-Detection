using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace xssiServer.Models
{
    [Table("ScriptHolder")]
    public class ScriptHolder
    {
        public ScriptHolder()
        {
            ContentWithLogin = "";
            ContentWithOutLogin = "";
        }

        [Key]
        public int Id { get; set; }
        public int Number { get; set; }
        public string Source { get; set; }
        public string ContentWithLogin { get; set; }
        public string ContentWithOutLogin { get; set; }
        public bool IsDynamic { get; set; }
        
    }

    
}