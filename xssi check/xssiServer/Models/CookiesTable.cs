using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace xssiServer.Models
{
    [Table("CookiesTable")]
    public class CookiesTable
    {
        [Key]
        public int Id { get; set; }
        public string Cookies { get; set; }
        public string TargetUrl { get; set; }
    }
}