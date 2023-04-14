using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PrjEmployeeManagement.Models;
using PrjEmployeeManagement.ViewModels;

namespace PrjEmployeeManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        EmployeeViewModel viewModel;
       // IEmployeeService _employeeService;

        public MainWindow( )
        {
            // IEmployeeService employeeService _employeeService = employeeService;
            InitializeComponent();
            viewModel = new EmployeeViewModel();
            this.DataContext = viewModel;
            Application.Current.MainWindow.WindowState = WindowState.Maximized;
        }
    }
}
