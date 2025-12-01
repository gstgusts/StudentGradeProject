using Students.MAUI.Services;

namespace Students.MAUI
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        private IStudentDataRepository _repo;

        public MainPage()
        {
            InitializeComponent();
            _repo = new StudentRepository();
        }

        private void OnCounterClicked(object? sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }

        private void OnLoadClicked(object? sender, EventArgs e)
        {
            var students = _repo.GetAll();
        }
    }
}
