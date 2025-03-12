// run.csx
#r "Newtonsoft.Json"
 
using System.Net;
using Newtonsoft.Json;
 
public class AzureMetrics {
    public double CPU { get; set; }
    public double Memory { get; set; }
    public int ActiveJobs { get; set; }
}
 
public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, ILogger log) {
    // Mocked metrics (replace with Azure Monitor API calls)
    AzureMetrics metrics = new AzureMetrics { CPU = 68, Memory = 72, ActiveJobs = 10 };
    int loadScore = (int)((metrics.CPU + metrics.Memory) / 2);
 
    return new HttpResponseMessage {
        Content = new StringContent(JsonConvert.SerializeObject(new {
            loadScore,
            recommendation = loadScore > 75 ? "Delay scheduling: High server load" : "Optimal time to schedule"
        }), Encoding.UTF8, "application/json")
    };
}