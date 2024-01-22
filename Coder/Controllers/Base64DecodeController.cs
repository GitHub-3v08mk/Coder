using Microsoft.AspNetCore.Mvc;

namespace Coder.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Base64DecodeController : ControllerBase
    {

        private readonly ILogger<Base64DecodeController> _logger;

        public Base64DecodeController(ILogger<Base64DecodeController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetBase64Decode")]
        public String Get([FromQuery] String text)
        {

            //Get Environment Variables
            string hostingStrategy = Environment.GetEnvironmentVariable("HOSTINGSTRATEGY");
            string hostingService = Environment.GetEnvironmentVariable("HOSTINGSERVICE");

            //Log to Volume
            String outputVolumeMount = "Default Message";
            try
            {

                string line = $"{DateTime.Now} - Coder called successfully in {hostingService}";

                string filePath = "/data/logs/logfile-coder.txt";
                if (!System.IO.File.Exists(filePath)) { using (FileStream fs = System.IO.File.Create(filePath)) { } }
                System.IO.File.AppendAllText(filePath, line + Environment.NewLine);
                
                outputVolumeMount = "Mounted Successfully - " + line;

            }
            catch (Exception ex) { outputVolumeMount = ex.ToString(); }

            String plaintText = "";
            byte[] bytes = Convert.FromBase64String(text);
            plaintText = System.Text.Encoding.UTF8.GetString(bytes);

            return plaintText;

        }
    }
}