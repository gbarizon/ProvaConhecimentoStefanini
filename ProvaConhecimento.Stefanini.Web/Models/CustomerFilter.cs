using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProvaConhecimento.Stefanini.Web.Models
{
    public class CustomerFilter
    {
        public string Name { get; set; }
        public int IdGender { get; set; }

        public int IdCity { get; set; }

        public int IdRegion { get; set; }

        public int IdClassification { get; set; }

        public int IdUser { get; set; }

        public DateTime? LastPurchase { get; set;}

        public DateTime? PurchaseUntil { get; set; }
     
        public List<SelectListItem> Genders { get; set; }
        public List<SelectListItem> Cities { get; set; }

        public List<SelectListItem> Regions { get; set; }

        public List<SelectListItem> Classifications { get; set; }

        public List<SelectListItem> Users { get; set; }
    }
}