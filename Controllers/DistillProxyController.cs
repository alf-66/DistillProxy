using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DistillProxy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DistillProxy : ControllerBase
    {

        public DistillProxy(ILogger<DistillProxy> logger)
        {
        }

        [HttpGet]
        public string Get()
        {
            string Message = HttpContext.Request.Query["message"].ToString();

            if (!String.IsNullOrEmpty(Message))
            {
                string Url = HttpContext.Request.Query["url"].ToString();
                string Token = "XXXXX";
                string User = "XXXXX";

                var httpclient = new HttpClient();
                var url = "https://api.pushover.net/1/messages.json";
                var parameters = new Dictionary<string, string> { { "token", Token }, { "user", User }, { "message", Message }, { "title", "Webseite changed" } };
                if (!String.IsNullOrEmpty(Url))
                {
                    parameters.Add("url", Url);
                }

                var encodedContent = new FormUrlEncodedContent(parameters);

                httpclient.PostAsync(url, encodedContent);
            }

            return "1";
        }
    }
}
