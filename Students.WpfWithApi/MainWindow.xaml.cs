using Newtonsoft.Json;
using RestSharp;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Students.WpfWithApi.Models;

namespace Students.WpfWithApi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void DataGrid_Initialized(object sender, EventArgs e)
        {
            var options = new RestClientOptions("https://localhost:7213")
            {
                Timeout = TimeSpan.FromSeconds(5),
            };
            var client = new RestClient(options);
            var request = new RestRequest("/api/students", Method.Get);
            RestResponse response = client.ExecuteAsync(request).Result;

            List<Student> students = JsonConvert.DeserializeObject<List<Student>>(response.Content);

            DataGrid.ItemsSource = students;
        }
    }
}