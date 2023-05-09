using Azure.Security.KeyVault.Secrets;
using Microsoft.AspNetCore.Mvc;
using MvcKeyVault.Models;
using System.Diagnostics;

namespace MvcKeyVault.Controllers
{
    public class HomeController : Controller
    {
        private SecretClient secretClient;

        public HomeController(SecretClient secretClient)
        {
            this.secretClient = secretClient;
        }

        [HttpPost]
        public async Task<IActionResult> Index(string secretkey)
        {
            KeyVaultSecret keyVaultSecret =
                await this.secretClient.GetSecretAsync(secretkey);
            ViewData["SECRETO"] = keyVaultSecret.Value;
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}