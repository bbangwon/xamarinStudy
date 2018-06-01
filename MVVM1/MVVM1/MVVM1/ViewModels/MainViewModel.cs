using MVVM1.Models;
using MVVM1.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace MVVM1.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private List<Employee> _employeesList;

        public List<Employee> EmployeesList {
            get => _employeesList;
            set
            {
                _employeesList = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            var employeesServices = new EmployeesServices();

            EmployeesList = employeesServices.GetEmployees();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
