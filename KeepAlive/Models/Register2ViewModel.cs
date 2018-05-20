using KeepAlive.Web.Extensions.Html;
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
        [Display(Description = "Seleziona la domanda segreta")]
        public int DomandaSegreta { get; set; }

        [Required]
        [Display(Description = "Rispondi alla domanda segreta che hai scelto")]
        public string RispostaSegreta { get; set; }

        //public IEnumerable<string> DomandeSegrete { get; set; }

        //public IEnumerable<SelectListItem> DomandeSegreteItems {
        //    get
        //    {
        //        return DomandeSegrete.ToSelectList(x => )
        //    }
        //}

        public Dictionary<int, string> DomandeSegrete = new Dictionary<int, string>()
        {
            { 1, "Qual è il primo nome del tuo pene?" },
            { 2, "Come ti piace quella cosa?" },
            { 3, "Ci arrivi a 10cm?" }
        };

        //public IEnumerable<SelectListItem> DomandeSegreteItems
        //{
        //    get
        //    {
        //        return DomandeSegrete.AsEnumerable
        //    }
        //}

    }
}