using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rohan_Phadtare_DotnetAssignment7_LINQFiltering
{
    internal class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        public override string ToString()
        {
            return $"Id: {DepartmentId}, Department Name: {DepartmentName}";
        }
    }
}
