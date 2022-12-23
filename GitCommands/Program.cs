using System;
using System.Collections.Generic;
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

            #region take 20

            // var twentyEmployees = employees.Take(20).ToList();
            //
            // foreach (var employee in twentyEmployees)
            // {
            //     Console.WriteLine($"ID: {employee.Id}, Name: {employee.Name}, Age: {employee.Age}");
            // }

            #endregion

            #region Where

            // // var adultEmployees = employees.Where(e => e.Age >= 18);
            //
            // var adultEmployees = from employee in employees
            //     where employee.Age == 30
            //     select employee;
            //
            // PrintEmployees(adultEmployees);

            #endregion

            #region OrderBy / OrderByDesending / ThenBy / ThenByDesending / Reverse

            //OrderBy + Reverse
            // var orderedAgeEmployees = employees.OrderBy(u => u.Age);
            // PrintEmployees(orderedAgeEmployees);
            // var reversedOrder = orderedAgeEmployees.Reverse();
            // PrintEmployees(reversedOrder);

            //OrderBy syntax
            // var orderedAgeEmployees = from employee in employees
            //     orderby employee.Age descending
            //     select employee;
            //PrintEmployees(orderedAgeEmployees);
            
            //ThenBy
            // var orderedAgeThenNameEmployees = employees.OrderBy(e => e.Age)
            //                                                                     .ThenBy(e => e.Name);
            // PrintEmployees(orderedAgeThenNameEmployees);

            #endregion

            #region GrouBy
            
            // //method
            // //var groupByAge = employees.GroupBy(e => e.Age);
            //
            // //syntax
            // var groupByAge = from e in employees
            //                                         group e by e.Name;
            //
            // foreach (var ageGroup in groupByAge)
            // {
            //     Console.WriteLine($"Age Group {ageGroup.Key}");
            //
            //     PrintEmployees(ageGroup);
            //
            //     Console.WriteLine("========================");
            // }

            #endregion

            #region Join

            // IList<Student> studentList = new List<Student>() { 
            //     new Student() { StudentID = 1, StudentName = "John", StandardID =1 },
            //     new Student() { StudentID = 2, StudentName = "Moin", StandardID =1 },
            //     new Student() { StudentID = 3, StudentName = "Bill", StandardID =2 },
            //     new Student() { StudentID = 4, StudentName = "Ram" , StandardID =2 },
            //     new Student() { StudentID = 5, StudentName = "Ron"  } 
            // };
            //
            // IList<Standard> standardList = new List<Standard>() { 
            //     new Standard(){ StandardID = 1, StandardName="Standard 1"},
            //     new Standard(){ StandardID = 2, StandardName="Standard 2"},
            //     new Standard(){ StandardID = 3, StandardName="Standard 3"}
            // };
            //
            // // syntax
            // // var data = from s in studentList
            // //     join std in standardList
            // //         on s.StudentID equals std.StandardID
            // //     select new
            // //     {
            // //         s.StudentName,
            // //         std.StandardName
            // //     };
            //
            // //method
            // var data = studentList.Join(
            //     standardList, 
            //     student => student.StandardID, 
            //     standard => standard.StandardID,
            //     (student, standard) => new
            //     {
            //         student.StudentName,
            //         standard.StandardName
            //     });
            //
            // foreach (var d in data)
            // {
            //     Console.WriteLine($"Student: {d.StudentName}, Standard: {d.StandardName}");
            // }

            #endregion

            #region Left Join

            // IList<Student> studentList = new List<Student>() { 
            //     new Student() { StudentID = 1, StudentName = "John", StandardID =1 },
            //     new Student() { StudentID = 2, StudentName = "Moin", StandardID =1 },
            //     new Student() { StudentID = 3, StudentName = "Bill", StandardID =2 },
            //     new Student() { StudentID = 4, StudentName = "Ram" , StandardID =2 },
            //     new Student() { StudentID = 5, StudentName = "Ron"  } 
            // };
            //
            // IList<Standard> standardList = new List<Standard>() { 
            //     new Standard(){ StandardID = 1, StandardName="Standard 1"},
            //     new Standard(){ StandardID = 2, StandardName="Standard 2"},
            //     new Standard(){ StandardID = 3, StandardName="Standard 3"}
            // };
            //
            // var data = from student in studentList
            //     join standard in standardList
            //         on student.StandardID equals standard.StandardID into gj
            //     from subData in gj.DefaultIfEmpty()
            //     select new
            //     {
            //         student.StudentName,
            //         StandardName = subData?.StandardName ?? string.Empty
            //     };
            //
            // foreach (var d in data)
            // {
            //     Console.WriteLine($"Student: {d.StudentName}, Standard: {d.StandardName}");
            // }

            #endregion

            #region Select

            var employeeNames = employees.Select(u => u.Name);
            foreach (var name in employeeNames)
            {
                Console.WriteLine(name);
            }

            #endregion


        }

        private static void PrintEmployees(IEnumerable<Employee> employees)
        {
            foreach (var employee in employees)
            {
                Console.WriteLine($"ID: {employee.Id}, Name: {employee.Name}, Age: {employee.Age}");            }
        }

        
    }
    
    public class Student{ 
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public int StandardID { get; set; }
    }

    public class Standard{ 
        public int StandardID { get; set; }
        public string StandardName { get; set; }
    }
}
