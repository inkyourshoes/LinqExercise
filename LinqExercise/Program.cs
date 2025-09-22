using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        public Program()
        {
        }


        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax. 
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //TODO: Print the Sum of numbers
            
            var sum = numbers.Sum();

            //TODO: Print the Average of numbers
            
            var average = numbers.Average();
            Console.WriteLine($"Sum: {sum}");
            Console.WriteLine($"Average: {average}");

            //TODO: Order numbers in ascending order and print to the console
            
            var asc = numbers.OrderBy(num => num);
            Console.WriteLine("--------------");
            Console.WriteLine("Ascending");

            foreach (var num in asc)
            {
              Console.WriteLine(num);  
            }

            //TODO: Order numbers in descending order and print to the console
            
            var desc = numbers.OrderByDescending(x => x);
            Console.WriteLine("--------------");
            Console.WriteLine("Descending");

            foreach (var num in desc)
            {
                Console.WriteLine(num);
            }

            //TODO: Print to the console only the numbers greater than 6
            
            var greaterThanSix = numbers.Where(num => num > 6);
            Console.WriteLine("--------------");
            Console.WriteLine("Greater than 6");

            foreach (var item in greaterThanSix)
            {
                Console.WriteLine(item);
            }

            //TODO: Order numbers in any order (ascending or desc) but only print 4 of them **foreach loop only!**
            var firstFour = asc.Take(4);
            
            Console.WriteLine("--------------");
            Console.WriteLine("First 4 asc");
            
            foreach (var num in firstFour)
            {
                Console.WriteLine(num);
            }
            

            //TODO: Change the value at index 4 to your age, then print the numbers in descending order
            
            numbers[4] = 35;
            foreach (var item in numbers.OrderByDescending(num => num))
            {
                Console.WriteLine(item);
            }
            
            
            

            // List of employees ****Do not remove this****
            
            var employees = CreateEmployees();
            
            //print all employees fullName properties to the console
            Console.WriteLine("--------------");
            Console.WriteLine("Employees");
            
            //print all employees fullName properties to the console only if their first name starts with a C or an S.
            //Order this is ascending order by FirstName
            
            var filtered = 
                employees.Where(person => person.FirstName.StartsWith('C') || person.FirstName.StartsWith('S'))
                .OrderBy(person => person.FirstName);
            Console.WriteLine("--------------");
            Console.WriteLine("C or S Employees");
            foreach (var employee in filtered)
            {
                Console.WriteLine(employee.FullName);
            }

            var overTwentySix = employees.Where(person => person.Age > 26)
                .OrderBy(emp => emp.Age).ThenBy(emp => emp.FirstName);
            Console.WriteLine("--------------");
            Console.WriteLine("Over 26");
            foreach (var person in overTwentySix)
            {
                Console.WriteLine($"Age: {person.Age} Fullname: {person.FirstName} YOE: {person.YearsOfExperience}");
            }

            //TODO: Print the Sum of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.
            //var yoeEmployees = employees.Where(x => x.YearsOfExperience <= 10 && x.Age > 35).Sum(x => x.YearsOfExperience);

            var yoeEmployees = employees.Where(x => x.YearsOfExperience <= 10 && x.Age > 35);
            var sumOfYoe = yoeEmployees.Sum(emp => emp.YearsOfExperience);
            var avgOfYoe = yoeEmployees.Average(emp => emp.YearsOfExperience);
            
            

            //var sumOfYoe = yoeEmployees.Sum (emp => emp.YearsOfExperience);
            
            
            Console.WriteLine("--------------");
            Console.WriteLine("Years of Experience < 10 and Age > 35");
            //Console.WriteLine($"Sum = {sumOfYoe}, Avg = {avgOfYoe}");
            

            //TODO: Now print the Average of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.
            
            var avgOfYoeEmployees = employees.Where(x => x.YearsOfExperience <= 10 && x.Age > 35);
            var avgOfYoeEmployees2 = avgOfYoeEmployees.Average(emp => emp.YearsOfExperience);
            Console.WriteLine($"Avg YOE: {avgOfYoeEmployees2}");
            foreach (var emp in avgOfYoeEmployees)
            {
                Console.WriteLine($"Age: {emp.Age} Fullname: {emp.FirstName} YOE: {emp.YearsOfExperience}");
            }
            
            

            //TODO: Add an employee to the end of the list without using employees.Add()
            
            var years = employees.Where(x => x.YearsOfExperience <= 10 && x.Age > 35);
            


            Console.WriteLine($"Sum {sumOfYoe} , Avg {avgOfYoe}");

            Console.ReadLine();
        }
        
        
        

        #region CreateEmployeesMethod
        
        
        private static List<Employee> CreateEmployees()
        
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));
            
            employees = employees.Append (new Employee("Lebron", "James", 42, 1)).ToList();
            foreach (var emp in employees)
            {
                Console.WriteLine($"{emp.FirstName} {emp.Age}");
            }

            return employees;
        }
        #endregion
    }
}
