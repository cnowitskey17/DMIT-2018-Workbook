<Query Kind="Expression">
  <Connection>
    <ID>05a2444e-14ea-4451-ad3d-3398e9ff7898</ID>
    <Server>.</Server>
    <Database>WestWind</Database>
  </Connection>
</Query>

// Look up the Employees, sorted by last name then first name. Show the last/first name as distinct properties.
from person in Employees
orderby person.LastName, person.FirstName
select new
{
    person.FirstName,
	person.LastName
}