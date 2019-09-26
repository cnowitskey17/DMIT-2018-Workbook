<Query Kind="Expression">
  <Connection>
    <ID>697cb14f-6eec-4ebe-8740-fe67fb0700ec</ID>
    <Server>.</Server>
    <Database>WestWind</Database>
  </Connection>
</Query>

// List all the employees who are managers.
from person in Employees
//   employee     Table<Employees>  
where person.ReportsToChildren.Count > 0
//     Employee    IEnumerable<Employee>
select new
{
  Name = person.FirstName + " " + person.LastName,
  Subordinates = 	from sub in person.ReportsToChildren
  					select sub.FirstName + " " + sub.LastName
}