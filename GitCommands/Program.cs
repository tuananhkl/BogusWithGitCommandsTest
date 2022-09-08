using System;
using System.Linq;
using Bogus;

namespace GitCommands
{
    class Program
    {
        static void Main(string[] args)
        {
            var employees = new Faker<Employee>()
                .RuleFor(x => x.Id, x => Guid.NewGuid())
                .RuleFor(x => x.Name, x => x.Person.LastName)
                .RuleFor(x => x.Age, x => 2022 - x.Person.DateOfBirth.Year)
                .Generate(100);

            var twentyEmployees = employees.Take(20).ToList();

            foreach (var employee in twentyEmployees)
            {
                Console.WriteLine($"ID: {employee.Id}, Name: {employee.Name}, Age: {employee.Age}");
            }
        }
    }
}
