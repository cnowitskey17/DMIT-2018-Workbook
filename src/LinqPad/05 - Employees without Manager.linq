<Query Kind="Expression">
  <Connection>
    <ID>697cb14f-6eec-4ebe-8740-fe67fb0700ec</ID>
    <Server>.</Server>
    <Database>WestWind</Database>
  </Connection>
</Query>

// List all the employees who do not have a manager
// (i.e.: they do not report to anyone).
from person in Employees
//   Employee    Table<Employees> 
where person.ReportsToEmployee == null
//   Employee     Employee 
select new //anonymous datatype
//the curly braces section below is called the initializer list
{
  Name = person.FirstName + " " + person.LastName
}