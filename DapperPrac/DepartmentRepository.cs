using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperPrac;

internal class DepartmentRepository : IDepartmentRepository
{
    private readonly IDbConnection _connection;
    public DepartmentRepository(IDbConnection connection)
    {
        _connection = connection;
    }

    public IEnumerable<Department> GetAllDepartments()
    {
        return _connection.Query<Department>("SELECT * FROM departments");
    }

    public void insertDepartment(string newDepartmentName)
    {
        _connection.Execute("INSERT INTO departments (Name) VALUES (@name);",
            new { name = newDepartmentName });
    }

    public void UpdateDepartment(int id, string newName)
    {
        _connection.Execute("UPDATE departments SET Name = @newName WHERE DepartmentID = @id;",
                             new { newName = newName, id = id });
    }
}
