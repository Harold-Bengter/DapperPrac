using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperPrac;

internal interface IDepartmentRepository
{
    public IEnumerable<Department> GetAllDepartments();
    void insertDepartment(string newDepartmentName);
}
