﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeepAlive.Web.Helpers
{
    public class CaptchaHelper
    {
        public static CaptchaResponse ValidateCaptcha(string response)  
        {  
            string secret = System.Web.Configuration.WebConfigurationManager.AppSettings["recaptchaPrivateKey"];  
            var client = new WebClient();  
            var jsonResult = client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secret, response));  
            return JsonConvert.DeserializeObject < CaptchaResponse > (jsonResult.ToString());  
        }
    }
}
