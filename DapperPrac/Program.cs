using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using DapperPrac;
//^^^^MUST HAVE USING DIRECTIVES^^^^

IConfigurationRoot config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
string connString = config.GetConnectionString("DefaultConnection");
IDbConnection conn = new MySqlConnection(connString);

var repo = new DepartmentRepository(conn);

Console.WriteLine("Please enter a new name for a department");

var newDepartment = Console.ReadLine();

repo.insertDepartment(newDepartment);

var departments = repo.GetAllDepartments();

foreach (var department in departments)
{
    Console.WriteLine(department.DepartmentID);
    Console.WriteLine(department.Name);
    Console.WriteLine();
    Console.WriteLine();
}
var productRepo = new DapperProductRepository(conn);

Console.WriteLine("Please enter the information needed for a new product:");
Console.WriteLine();
Console.Write("Name:");
var pName = Console.ReadLine();
Console.Write("Price:");
var pPrice = double.Parse(Console.ReadLine());
Console.Write("Product category:");
var pCatID = int.Parse(Console.ReadLine());

Console.WriteLine($"Inserting new product '{pName}'");

productRepo.CreateProduct(pName, pPrice, pCatID);

var products = productRepo.GetAllProducts();

foreach (var p in products)
{
    Console.WriteLine(p.ProductID);
    Console.WriteLine(p.Name);
    Console.WriteLine(p.Price);
    Console.WriteLine(p.CategoryID);
    Console.WriteLine(p.OnSale);
    Console.WriteLine(p.StockLevel);
}