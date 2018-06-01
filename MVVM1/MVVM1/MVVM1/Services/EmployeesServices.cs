using MVVM1.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVVM1.Services
{
    public class EmployeesServices
    {
        public List<Employee> GetEmployees()
        {
            var list = new List<Employee>
            {
                new Employee
                {
                    Name = "Mohamed",
                    Department = "Marketing"
                },
                new Employee
                {
                    Name = "Hassen",
                    Department = "Sales"
                },
                new Employee
                {
                    Name = "Ahmed",
                    Department = "Finance"
                },
                new Employee
                {
                    Name = "Nader",
                    Department = "Sales"
                }
            };
            return list;
        }
    }
}
