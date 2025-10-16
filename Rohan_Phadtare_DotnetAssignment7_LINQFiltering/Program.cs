using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rohan_Phadtare_DotnetAssignment7_LINQFiltering
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>
            {
                new Employee { Id = 1, Name = "John", Salary = 60000, DepartmentId = 1 },
                new Employee { Id = 2, Name = "Sarah", Salary = 50000, DepartmentId = 2 },
                new Employee { Id = 3, Name = "Steve", Salary = 70000, DepartmentId = 1 },
                new Employee { Id = 4, Name = "Anna", Salary = 80000, DepartmentId = 3 },
                new Employee { Id = 5, Name = "Mike", Salary = 65000, DepartmentId = 3 },
                new Employee { Id = 6, Name = "John", Salary = 60000, DepartmentId = 1 }
            };

            
            List<Department> departments = new List<Department>
            {
                new Department { DepartmentId = 1, DepartmentName = "IT" },
                new Department { DepartmentId = 2, DepartmentName = "HR" },
                new Department { DepartmentId = 3, DepartmentName = "Finance" }
            };

            Console.WriteLine("============== LINQ Query Examples ==============\n");

          
            Console.WriteLine("1. Employees whose Salary > 60000:");
            var highSalaryEmployees = employees.Where(e => e.Salary > 60000);
            foreach (var emp in highSalaryEmployees)
                Console.WriteLine($"   {emp.Name} - ${emp.Salary}");

         
            Console.WriteLine("\n2. Employee Names and Salaries (Anonymous Type):");
            var employeeProjection = employees.Select(e => new { e.Name, e.Salary });
            foreach (var emp in employeeProjection)
                Console.WriteLine($"   Name: {emp.Name}, Salary: ${emp.Salary}");

            Console.WriteLine("\n3A. Employees Sorted by Name (Ascending):");
            var sortedByName = employees.OrderBy(e => e.Name);
            foreach (var emp in sortedByName)
                Console.WriteLine($"   {emp.Name} - ${emp.Salary}");

            Console.WriteLine("\n3B. Employees Sorted by Salary (Descending):");
            var sortedBySalary = employees.OrderByDescending(e => e.Salary);
            foreach (var emp in sortedBySalary)
                Console.WriteLine($"   {emp.Name} - ${emp.Salary}");

      
            Console.WriteLine("\n4. Employees Grouped by Department ID:");
            var groupedByDept = employees.GroupBy(e => e.DepartmentId);
            foreach (var group in groupedByDept)
            {
                Console.WriteLine($"Department ID: {group.Key}");
                foreach (var emp in group)
                    Console.WriteLine($"   - {emp.Name}");
            }

          
            Console.WriteLine("\n5A. Inner Join - Employees with Department Names:");
            var employeeDeptJoin = employees.Join(
                departments,
                e => e.DepartmentId,
                d => d.DepartmentId,
                (e, d) => new { e.Name, d.DepartmentName });

            foreach (var item in employeeDeptJoin)
                Console.WriteLine($"   {item.Name} - {item.DepartmentName}");

            Console.WriteLine("\n5B. Group Join - Departments with Their Employees:");
            var deptWithEmployees = departments.GroupJoin(
                employees,
                d => d.DepartmentId,
                e => e.DepartmentId,
                (d, empGroup) => new { d.DepartmentName, Employees = empGroup });

            foreach (var dept in deptWithEmployees)
            {
                Console.WriteLine($"   {dept.DepartmentName} Department:");
                foreach (var emp in dept.Employees)
                    Console.WriteLine($"      - {emp.Name}");
            }

       
            Console.WriteLine("\n6. Distinct Employee Names:");
            var distinctNames = employees.Select(e => e.Name).Distinct();
            foreach (var name in distinctNames)
                Console.WriteLine($"   {name}");

            Console.WriteLine("\n7. Pagination - 2nd Page (2 Employees per page):");
            var secondPage = employees.OrderBy(e => e.Id).Skip(2).Take(2);
            foreach (var emp in secondPage)
                Console.WriteLine($"   {emp.Name} - ${emp.Salary} - Dept ID: {emp.DepartmentId}");
        }
    }
}
