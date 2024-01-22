using Microsoft.AspNetCore.Mvc;

namespace Coder.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Base64CodeController : ControllerBase
    {

        private readonly ILogger<Base64CodeController> _logger;

        public Base64CodeController(ILogger<Base64CodeController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetBase64Code")]
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

            String base64Text = "";
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(text);
            base64Text = Convert.ToBase64String(bytes);

            return base64Text;

        }
    }
}