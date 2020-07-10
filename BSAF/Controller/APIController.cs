using BSAF.Helper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using BSAF.Models.ViewModels;

namespace BSAF.Controller
{
    public class APIController
    {
        public APIController()
        {
            
        }

        public static bool SubmitBeneficiary(BeneficiaryVM model)
        {
            string endpoint = Variables.beneficiaryUrl;
            string method = "POST";
            string json = JsonConvert.SerializeObject(model);
            try
            {
                using (WebClient client = new WebClient())
                {
                    client.Headers["Content-Type"] = "application/json";
                    client.Headers["Authorization"] = "Bearer " + UserInfo.token;
                    client.Encoding = Encoding.UTF8;
                    string response = client.UploadString(endpoint, method, json);
                    return JsonConvert.DeserializeObject<bool>(response);
                }
            } catch(Exception ex)
            {
                return false;
            }
            //WebClient wc = new WebClient();
            //wc.Headers["Content-Type"] = "application/json";
            //wc.Headers["Authorization"] = "Bearer "+UserInfo.token;
            //try
            //{
            //    string response = wc.UploadString(endpoint, method, json);
            //    return JsonConvert.DeserializeObject<bool>(response);
            //}
            //catch (Exception e)
            //{
            //    return false;
            //}
        }

    }
}
