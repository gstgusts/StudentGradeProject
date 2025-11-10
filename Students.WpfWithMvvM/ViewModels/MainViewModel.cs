using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Students.DataAccess;
using Students.DataAccess.Interfaces;
using Students.DataAccess.Services;

namespace Students.WpfWithMvvM.ViewModels
{
    public class MainViewModel : ObservableObject, INotifyPropertyChanged
    {
        private readonly IStudentRepository _repo;

        public MainViewModel()
        {
            _repo = new StudentRepositoryService(new StudentDbContext());
            SelectStudentCommand = new RelayCommand(LoadGrades);
        }

        private Student[] _students;

        public Student[] Students => _students;

        public void Load()
        {
            _students = _repo.GetAll().ToArray();
        }

        private List<Grade> _grades = new List<Grade>();

        public List<Grade> Grades
        {
            get => _grades;

            set
            {
                _grades = value;
                OnPropertyChanged();
            }
        }

        public Student SelectedStudent { get; set; }

        public void LoadGrades()
        {
            if (SelectedStudent == null)
            {
                return;
            }

            Grades = _repo.GetGrades(SelectedStudent.Id).ToList();
        }

        public ICommand SelectStudentCommand { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
