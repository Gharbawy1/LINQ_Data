using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projection
{
    internal class employees
    {
        int Id;
        string fname;
        string lname;
        string email;
        string phoneNumber;
        DateTime hireDate;
        int jobId;
        decimal salary;
        int departmentId;

        public override string ToString()
        {
            return  $"id = {Id} ,, fullname : {fname} {lname}";
        }

    }
}
