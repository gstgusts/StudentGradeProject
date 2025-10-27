using Newtonsoft.Json;
using RestSharp;
using Students.ConsoleWithApi.Models;

namespace Students.ConsoleWithApi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //GetStudentsUsingHttpClient();

            GetStudentsUsingRestSharp();
        }

        private static void GetStudentsUsingRestSharp()
        {
            var options = new RestClientOptions("https://localhost:7213")
            {
                Timeout = TimeSpan.FromSeconds(5),
            };
            var client = new RestClient(options);
            var request = new RestRequest("/api/students", Method.Get);
            RestResponse response = client.ExecuteAsync(request).Result;

            List<Student> students = JsonConvert.DeserializeObject<List<Student>>(response.Content);
        }

        private static void GetStudentsUsingHttpClient()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:7213/api/students");
            var response = client.Send(request);
            response.EnsureSuccessStatusCode();

            var result = response.Content.ReadAsStringAsync().Result;

            List<Student> students = JsonConvert.DeserializeObject<List<Student>>(result);
        }
    }
}
