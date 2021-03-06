﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace xssiServer.Models
{
    [Table("GenericScriptHolder")]
    public class GenericScriptHolder
    {
        [Key]
        public int Id { get; set; }
        public int Number { get; set; }
        public string Source { get; set; }
        [AllowHtml]
        public string Content { get; set; }
        
    }
}