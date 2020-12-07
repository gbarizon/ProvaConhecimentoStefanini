using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProvaConhecimento.Stefanini.Web.Models
{
    public class Gender
    {
        [Key, Column(Order = 1)]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int IdGender { get; set; }

        [Required]       
        public int Code { get; set; }

        [Required]
        [StringLength(100)]
        public string Description { get; set; }
    }
}