using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProvaConhecimento.Stefanini.Web.Models
{
    public class Customer
    {
        [Key, Column(Order = 1)]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int IdCustomer { get; set; }
      

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Phone { get; set; }

        public DateTime? LastPurchase { get; set; }

        public int IdClassification { get; set; }

        [ForeignKey("IdClassification")]
        public virtual Classification Classification { get; set; } //vip, regular or Sporadic

        public int IdGender { get; set; }

        [ForeignKey("IdGender")]
        public virtual Gender Gender { get; set; }

        public int IdCity { get; set; }

        [ForeignKey("IdCity")]
        public virtual City City { get; set; }

        public int IdRegion { get; set; }

        [Required]
        [ForeignKey("IdRegion")]
        public virtual Region Region { get; set; }    

        public int IdUser { get; set; }

        [ForeignKey("IdUser")]
        public virtual User User { get; set; }       
    }
}