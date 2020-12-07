using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProvaConhecimento.Stefanini.Web.Models;

namespace ProvaConhecimento.Stefanini.Web.ViewModel
{
    public class CustomerViewModel
    {
        public List<Customer> Customers { get; set; }
        public User User { get; set; }

        public CustomerFilter CustomerFilter { get; set; }
    }
}