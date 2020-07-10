using BSAF.Controller;
using BSAF.Models.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BSAF.Helper
{
    public class UserController
    {
        public UserController()
        {
        }
        public static string AuthenticateUser(string username, string password)
        {
            string endpoint = Variables.loginUrl ;
            string method = "POST";
            string json = JsonConvert.SerializeObject(new
            {
                Username = username,
                Password = password
            });
            try
            {
                using (WebClient client = new WebClient())
                {
                    client.CachePolicy = new System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.BypassCache);
                    client.Headers["Content-Type"] = "application/json";
                    var response = client.UploadString(endpoint, method, json);
                    if (response != null)
                    {
                        var jsonResponse = JsonConvert.DeserializeObject<JwtVM>(response);
                        UserInfo.token = jsonResponse.token;
                        var tokenHandler = new JwtSecurityTokenHandler();
                        var token = tokenHandler.ReadJwtToken(jsonResponse.token);
                        var cliams = token.Claims;
                        UserInfo.ID = cliams.Where(c => c.Type == "nameid").Select(c => c.Value).FirstOrDefault();
                        UserInfo.UserName = cliams.Where(c => c.Type == "unique_name").Select(c => c.Value).FirstOrDefault();
                        return "success"; 
                    }
                    return "failure";
                }

            }
            catch (Exception ex)
            {
                
                return ex.Message;
            }
        }

        //public UserInfo GetUserDetails(UserInfo user)
        //{
        //    string endpoint = this.baseUrl + "/users/" + user.Id;
        //    string access_token = UserInfo.access_token;

        //    WebClient wc = new WebClient();
        //    wc.Headers["Content-Type"] = "application/json";
        //    wc.Headers["Authorization"] = access_token;
        //    try
        //    {
        //        string response = wc.DownloadString(endpoint);
        //        user = JsonConvert.DeserializeObject<User>(response);
        //        user.access_token = access_token;
        //        return user;
        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //    }
        //}

        //public User RegisterUser(string username, string password, string firstname,
        //    string lastname, string middlename, int age)
        //{
        //    string endpoint = this.baseUrl + "/users";
        //    string method = "POST";
        //    string json = JsonConvert.SerializeObject(new
        //    {
        //        username = username,
        //        password = password,
        //        firstname = firstname,
        //        lastname = lastname,
        //        middlename = middlename,
        //        age = age
        //    });

        //    WebClient wc = new WebClient();
        //    wc.Headers["Content-Type"] = "application/json";
        //    try
        //    {
        //        string response = wc.UploadString(endpoint, method, json);
        //        return JsonConvert.DeserializeObject<User>(response);
        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //    }
        //}
    }
}
