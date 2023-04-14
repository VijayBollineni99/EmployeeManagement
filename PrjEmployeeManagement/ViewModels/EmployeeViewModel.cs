using PrjEmployeeManagement.Commands;
using PrjEmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PrjEmployeeManagement.ViewModels
{
    public class EmployeeViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private ObservableCollection<Employee> employees;
        public ObservableCollection<Employee> Employees
        {
            get { return employees; }
            set { employees = value; OnPropertyChanged("Employees"); }
        }


        EmployeeService employeeService;
     //   private readonly IEmployeeService _employeeService;
        public EmployeeViewModel()
        {

            //IEmployeeService employeeService _employeeService = employeeService;
            employeeService = new EmployeeService();
            LoadData();
            currentEmployee = new Employee();
            saveCommand = new RelayCommand(Save);
            deleteCommand = new RelayCommand(Delete);
            searchCommand = new RelayCommand(Search);
            updateCommand = new RelayCommand(Update);
        }
        private async void LoadData()
        {
            EmployeeService employeeService = new EmployeeService();
            Employees = await employeeService.GetAllEmployees();
        }

        private Employee currentEmployee;

        public Employee CurrentEmployee
        {
            get { return currentEmployee; }
            set { currentEmployee = value; OnPropertyChanged("CurrentEmployee"); }
        }

        private string message;

        public string Message
        {
            get { return message; }
            set { message = value; OnPropertyChanged("Message"); }
        }

        // Save Code
        private RelayCommand saveCommand;

        public RelayCommand SaveCommand
        {
            get { return saveCommand; }
        }
        public async void Save()
        {

            var employee = await employeeService.Add(CurrentEmployee);
            if (employee != null)
                MessageBox.Show($@" EmpID: {employee.Id} Saved successfully", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                MessageBox.Show("Not Saved", "Save error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        // Save Code END


        //Edit Code
        private RelayCommand updateCommand;

        public RelayCommand UpdateCommand
        {
            get { return updateCommand; }
            set { updateCommand = value; }
        }

        public async void Update()
        {
            if (CurrentEmployee.Id > 0)
            {
                var employee = await employeeService.Update(CurrentEmployee);
                if (employee != null && employee.Id > 0)
                    MessageBox.Show($@"EmpID: {employee.Id} Updated successfully", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                else
                    MessageBox.Show($@"EmpID: {employee.Id} Not Existed to Update", "Save error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        //Edit End


        //Delete code 
        private RelayCommand deleteCommand;

        public RelayCommand DeleteCommand
        {
            get { return deleteCommand; }
        }
        public async void Delete()
        {
            if (CurrentEmployee.Id > 0)
            {
                var Result = await employeeService.Delete(CurrentEmployee);
                if (Result == true)
                {
                    MessageBox.Show($@"Deleted successfully..", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show($@"Emp ID: {CurrentEmployee.Id} Not Exist..", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }
        // Delete end



        //Search code
        private RelayCommand searchCommand;

        public RelayCommand SearchCommand
        {
            get { return searchCommand; }
        }

        public async void Search()
        {
            if (CurrentEmployee.Id > 0)
            {
                var emp = await employeeService.GetEmployee(CurrentEmployee);
                if (emp != null)
                {
                    CurrentEmployee = emp;
                }
                else
                    MessageBox.Show($@"EmpID: {currentEmployee.Id} Not Found", "Save error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        //Search End
    }
}
