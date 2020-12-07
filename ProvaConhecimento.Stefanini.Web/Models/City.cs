using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProvaConhecimento.Stefanini.Web.Models
{
    public class City
    {
        [Key, Column(Order = 1)]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int IdCity { get; set; }

        [Required]
        public string Name { get; set; }

        public int IdRegion { get; set; }

        [ForeignKey("IdRegion")]
        public virtual Region Region { get; set; }
    }        
}