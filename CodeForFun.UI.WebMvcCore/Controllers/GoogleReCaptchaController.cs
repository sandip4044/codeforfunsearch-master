using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CodeForFun.UI.WebMvcCore.Models.ViewModels;
using CodeForFun.UI.WebMvcCore.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace CodeForFun.UI.WebMvcCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GoogleReCaptchaController : ControllerBase
    {

        private readonly ILogger<GoogleReCaptchaController> _logger;

        public GoogleReCaptchaController(ILogger<GoogleReCaptchaController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("[action]/{ParamT}")]
        //public IEnumerable<WeatherForecast> Get(string paramT)
        public ActionResult ValidGoogleReCaptcha(string recaptchaResponse)
        {
            //string recaptchaResponse = "03AERD8XqpNgyi1Wja_0q4sSFFlOyoal2j5jW4CXG9w_OXqc6c22PvqKbagciRa6qtBx4PzmKzUq3AFD9E1P_ENAA0_cMARUdKErUK-zjajzSN1e3o7nmhdZUmWOZ-jhMxQe1dnICb43oQQ8R4PnWE_s5C_eM2KUw9iFrZAjPuF5oHnXTtf1DlXk-fVeVdHa0-vWiquu_wTIA48ZpxFfEeYEE6QTxCiOuYDwgjT5OAy8FDvLBeUrig7XSvmIvZcGmq_IADOuSQflK0RahLqvqcu3qNUw_eAvpvoavlJUSnV1UJpDPp4StOCHdspsQjMRWLfwUPMxZukYJ_jyCy4VOhcknDId-9wPnEEmdoH3UCeD40aMB-XBueLMbXQUJnF1kglDGv96-5ulpk";
            string path = "https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}";
            var client = new WebClient();
            var reply = client.DownloadString(string.Format(path, AppConsts.GoogleSecret, recaptchaResponse));
            var captchaResponse = JsonConvert.DeserializeObject<CaptchaGoogle>(reply);
            List<WeatherForecast> lst = new List<WeatherForecast>();
            if (!captchaResponse.Success)
            {
                return Ok(captchaResponse.ErrorCodes);
            }
            else
            {
                return Ok("Success");
            }
        }

    }
}