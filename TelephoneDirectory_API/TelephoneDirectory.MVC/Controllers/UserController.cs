using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using TelephoneDirectory.MVC.Models;
using Newtonsoft.Json;

namespace TelephoneDirectory.MVC.Controllers
{
    public class UserController : Controller
    {
        Uri baseAddress =new Uri ("https://localhost:7257/api");
        HttpClient client;
        public UserController()
        {
            client = new HttpClient ();
            client.BaseAddress = baseAddress;
        }
        public IActionResult Index()
        { 
            List<UserViewModel> modelList = new List<UserViewModel> ();
            HttpResponseMessage response= client.GetAsync(baseAddress + "/User/EndPointGetAllUsers").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                modelList = JsonConvert.DeserializeObject<List<UserViewModel>>(data);
            }
            return View(modelList);
        }
    }
}
