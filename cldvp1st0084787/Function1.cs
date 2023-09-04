using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

public static class ST10084787
{
    [FunctionName("GetVaccinationStatus")]
    public static IActionResult Run(
    [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "id/{id}")] HttpRequest req,
    string id,
    ILogger log)
    {
        log.LogInformation("C# HTTP trigger function processed a request.");

        // List of hardcoded valid IDs
        string[] validIDs = { "0001195070089", "0201010986085", "0201019368087", "0201015087186", "0201018962187", "0201010236085", "0201011858184" };

        if (validIDs.Contains(id))
        {
            // Dummy vaccination data
            var vaccinationData = new
            {
                ID = id,
                Status = "Vaccinated",
                Date = "2023-09-04",
                Location = "South Africa"
            };

            return new OkObjectResult(vaccinationData);
        }
        else
        {
            return new BadRequestObjectResult("Invalid ID");
        }
    }
}
