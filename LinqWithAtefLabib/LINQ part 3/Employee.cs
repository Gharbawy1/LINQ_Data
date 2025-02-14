
using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQTut04.Shared
{
    // we will implment IComparable for the Aggregrate function
    public class Employee : IComparable<Employee>
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public List<string> Skills { get; set; } = new List<string>();

        public decimal Salary { get; set; }
        public string FullName => $"{FirstName} {LastName}";

        public int CompareTo(Employee ?e)=> Salary.CompareTo(e?.Salary); 

        public override string ToString()
        {

            return
                    $"" +
                    $"{Id}\t" +
                    $"{String.Concat(FirstName, " ", LastName).PadRight(30, ' ')}\t" +
                    $"{Email.PadRight(30, ' ')}\t" +
                    $"[ {string.Join(", ", Skills)} ]\t"+
                    $"Salary : {Salary}.";

        }
    }


}