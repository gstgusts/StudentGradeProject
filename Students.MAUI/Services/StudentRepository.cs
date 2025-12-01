using Students.MAUI.Models;
using RestSharp;
using Newtonsoft.Json;

namespace Students.MAUI.Services
{
    public class StudentRepository : IStudentDataRepository
    {
        public IEnumerable<Student> GetAll()
        {
            var options = new RestClientOptions("https://localhost:7213")
            {
                Timeout = TimeSpan.FromSeconds(5),
            };
            var client = new RestClient(options);
            var request = new RestRequest("/api/students", Method.Get);
            RestResponse response = client.ExecuteAsync(request).Result;

            List<Student> students = JsonConvert.DeserializeObject<List<Student>>(response.Content);

            return students;
        }
    }
}
