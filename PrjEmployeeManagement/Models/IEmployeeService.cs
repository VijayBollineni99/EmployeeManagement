using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrjEmployeeManagement.Models
{
    public interface IEmployeeService
    {
        Task<ObservableCollection<Employee>> GetAllEmployees();
        Task<Employee> GetEmployee(Employee employee);
        Task<Employee> Add(Employee employee);
        Task<bool> Delete(Employee employee);
        Task<Employee> Update(Employee employee);


    }
}
