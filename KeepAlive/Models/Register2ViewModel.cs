using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KeepAlive.Models
{
    public class Register2ViewModel
    {

        [Required]
        public int DomandaSegreta { get; set; }

        public Dictionary<int, string> DomandeSegrete = new Dictionary<int, string>()
        {
            { 1, "Qual è il primo nome del tuo pene?" },
            { 2, "Come ti piace quella cosa?" },
            { 3, "Ci arrivi a 10cm?" }
        }; 

        //public IEnumerable<SelectListItem> DomandeSegreteItems {
        //    get
        //    {
        //        return DomandeSegrete.AsEnumerable
        //    }
        //}
        
    }
}