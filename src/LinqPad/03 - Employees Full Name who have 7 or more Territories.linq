<Query Kind="Expression">
  <Connection>
    <ID>697cb14f-6eec-4ebe-8740-fe67fb0700ec</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WestWind</Database>
  </Connection>
</Query>

// List the full name of all the employees who look after 7 or more territories
from person in Employees
where person.EmployeeTerritories.Count >= 7
select person.FirstName + " " + person.LastName