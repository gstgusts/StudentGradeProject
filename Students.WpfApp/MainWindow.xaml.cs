using Students.DataAccess;
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
using Students.DataAccess.Interfaces;
using Students.DataAccess.Services;

namespace Students.WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IStudentRepository _studentRepository;
        public MainWindow()
        {
            InitializeComponent();

            _studentRepository = new StudentRepositoryService(new StudentDbContext());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var students = _studentRepository.GetAll();
            DataGrid.ItemsSource = students.Where(s => s.Name.Contains(SearchQuery.Text) || s.Surname.Contains(SearchQuery.Text));
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            DataGrid.ItemsSource = _studentRepository.GetAll();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            _studentRepository.Add(new Student
            {
                Code = StudentId.Text,
                Name = StudentName.Text,
                Surname = StudentName.Text
            });

            DataGrid.ItemsSource = _studentRepository.GetAll();
        }
    }
}