using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Dynamic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PrjEmployeeManagement.Models
{
    public class EmployeeService : IEmployeeService
    {
        public static readonly String baseURL = "https://gorest.co.in/public-api";
        public EmployeeService()
        {
        }
        public async Task<ObservableCollection<Employee>> GetAllEmployees()
        {
            ObservableCollection<Employee> employees = new ObservableCollection<Employee>();
            using (var client = new HttpClient())
            {
                var Message = new HttpRequestMessage(HttpMethod.Get, baseURL + "/users");
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer fa114107311259f5f33e70a5d85de34a2499b4401da069af0b1d835cd5ec0d56");
                var Responce = await client.SendAsync(Message);
                var Content = await Responce.Content.ReadAsStringAsync();
                JObject JObjectResult = JObject.Parse(Content);
                var ResponceEmployees = JObjectResult.SelectToken("data");
                foreach (var ResponceEmployee in ResponceEmployees)
                {
                    Employee employee = new Employee();
                    employee.Id = Convert.ToInt32(ResponceEmployee["id"]);
                    employee.Name = Convert.ToString(ResponceEmployee["name"]);
                    employee.Email = Convert.ToString(ResponceEmployee["email"]);
                    employee.Gender = Convert.ToString(ResponceEmployee["gender"]);
                    employee.Status = Convert.ToString(ResponceEmployee["status"]);
                    employees.Add(employee);
                }
                return employees;
            }
        }
        public async Task<Employee> Add(Employee employee)
        {
            Employee emp = new Employee();
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer fa114107311259f5f33e70a5d85de34a2499b4401da069af0b1d835cd5ec0d56");
                var EmployeeBodyjson = JsonConvert.SerializeObject(employee);
                var jsonSerializerSettings = new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                };
                var interimObject = JsonConvert.DeserializeObject<ExpandoObject>(EmployeeBodyjson);
                var myJsonOutput = JsonConvert.SerializeObject(interimObject, jsonSerializerSettings);
                var data = new StringContent(myJsonOutput, Encoding.UTF8, "application/json");
                var ApiResponse = await client.PostAsync(baseURL + "/users", data);
                if (ApiResponse.IsSuccessStatusCode)
                {
                    var JsonResponse = await ApiResponse.Content.ReadAsStringAsync();
                    JObject JObjectResult = JObject.Parse(JsonResponse);
                    var ResponceEmployee = JObjectResult.SelectToken("data");
                    emp.Id = Convert.ToInt32(ResponceEmployee["id"]);
                    emp.Name = Convert.ToString(ResponceEmployee["name"]);
                    emp.Email = Convert.ToString(ResponceEmployee["email"]);
                    emp.Gender = Convert.ToString(ResponceEmployee["gender"]);
                    emp.Status = Convert.ToString(ResponceEmployee["status"]);
                }
                return emp;
            }
        }
        public async Task<bool> Delete(Employee employee)
        {
            using (var client = new HttpClient())
            {
                var Message = new HttpRequestMessage(HttpMethod.Delete, baseURL + $@"/users/{employee.Id}");
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer fa114107311259f5f33e70a5d85de34a2499b4401da069af0b1d835cd5ec0d56");
                var Responce = await client.SendAsync(Message);
                if (Responce.IsSuccessStatusCode)
                {
                    var JsonResponse = await Responce.Content.ReadAsStringAsync();
                    JObject JObjectResult = JObject.Parse(JsonResponse);
                    var ResponceEmployee = JObjectResult.SelectToken("code");
                    if (ResponceEmployee.ToString() == "204")
                    {
                        return true;
                    }
                    else
                        return false;
                }
                else
                {
                    return false;
                }
            }
        }
        public async Task<Employee> Update(Employee employee)
        {
            Employee emp = new Employee();
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer fa114107311259f5f33e70a5d85de34a2499b4401da069af0b1d835cd5ec0d56");
                var EmployeeBodyjson = JsonConvert.SerializeObject(employee);
                var jsonSerializerSettings = new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                };
                var interimObject = JsonConvert.DeserializeObject<ExpandoObject>(EmployeeBodyjson);
                var myJsonOutput = JsonConvert.SerializeObject(interimObject, jsonSerializerSettings);

                var data = new StringContent(myJsonOutput, Encoding.UTF8, "application/json");
                var ApiResponse = await client.PutAsync(baseURL + $@"/users/{employee.Id}", data);
                if (ApiResponse.IsSuccessStatusCode)
                {
                    var JsonResponse = await ApiResponse.Content.ReadAsStringAsync();
                    JObject JObjectResult = JObject.Parse(JsonResponse);
                    var ResponceEmployee = JObjectResult.SelectToken("data");
                    if (JObjectResult.SelectToken("code").ToString() == "200")
                    {
                        emp.Id = Convert.ToInt32(ResponceEmployee["id"]);
                        emp.Name = Convert.ToString(ResponceEmployee["name"]);
                        emp.Email = Convert.ToString(ResponceEmployee["email"]);
                        emp.Gender = Convert.ToString(ResponceEmployee["gender"]);
                        emp.Status = Convert.ToString(ResponceEmployee["status"]);
                    }
                }
                return emp;
            }
        }

        public async Task<Employee> GetEmployee(Employee employee)
        {
            using (var client = new HttpClient())
            {
                var Message = new HttpRequestMessage(HttpMethod.Get, baseURL + $@"/users/{employee.Id}");
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer fa114107311259f5f33e70a5d85de34a2499b4401da069af0b1d835cd5ec0d56");
                var Responce = await client.SendAsync(Message);
                var Content = await Responce.Content.ReadAsStringAsync();
                JObject JObjectResult = JObject.Parse(Content);
                var ResponceEmployees = JObjectResult.SelectToken("data");
                Employee emp = new Employee();
                emp.Id = Convert.ToInt32(ResponceEmployees["id"]);
                emp.Name = Convert.ToString(ResponceEmployees["name"]);
                emp.Email = Convert.ToString(ResponceEmployees["email"]);
                emp.Gender = Convert.ToString(ResponceEmployees["gender"]);
                emp.Status = Convert.ToString(ResponceEmployees["status"]);
                return emp;
            }
        }
    }
}
