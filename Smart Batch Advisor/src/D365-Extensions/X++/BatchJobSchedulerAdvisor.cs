[ExtensionOf(formStr(BatchJob))]
final class BatchJobSchedulerAdvisor_Extension
{
    public void init()
    {
        next init();
        this.displayLoadAlert();
    }
 
    private void displayLoadAlert()
    {
var httpClient = new System.Net.Http.HttpClient();
var response = httpClient.GetAsync("https://your-azure-function-url").Result;
        var result = JsonConvert.DeserializeObject(response.Content.ReadAsStringAsync().Result);
 
FormControl trafficLight = this.design().controlName("TrafficLight");
        trafficLight.backgroundColor(result.loadScore > 75 ? "Red" : "Green");
        
        Info(result.recommendation);
    }
}