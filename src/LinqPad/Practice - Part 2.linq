<Query Kind="Expression">
  <Connection>
    <ID>18fd6fc2-264a-4d42-9004-833241e46611</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WestWind</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

// Practice questions - do each one in a separate LinqPad query.

// A) Group employees by region and show the results in this format:
/* ----------------------------------------------
 * | REGION        | EMPLOYEES                  |
 * ----------------------------------------------
 * | Eastern       | ------------------------   |
 * |               | | Nancy Devalio        |   |
 * |               | | Fred Flintstone      |   |
 * |               | | Bill Murray          |   |
 * |               | ------------------------   |
 * |---------------|----------------------------|
 * | ...           |                            |
 * 
 */
 
from reg in Regions
select new 
{
	Region = reg.RegionDescription,
	Employees = from area in reg.Territories
				from manager in area.EmployeeTerritories
				group manager by manager.Employee into areaManagers
				select areaManagers.Key.FirstName + " " + areaManagers.Key.LastName
}

// B) List all the Customers sorted by Company Name. Include the Customer's company name, contact name, and other contact information in the result.

from company in Customers 
select new
{
	CompanyName = company.CompanyName,
	Contact = new 
			{
				Name = company.ContactName,
				Title = company.ContactTitle,
				Email = company.ContactEmail,
				Phone = company.Phone,
				Fax = company.Fax
			}
}

//or

from company in Customers 
select new
{
	CompanyName = company.CompanyName,
				Name = company.ContactName,
				Title = company.ContactTitle,
				Email = company.ContactEmail,
				Phone = company.Phone,
				Fax = company.Fax
}

// C) List all the employees and sort the result in ascending order by last name, then first name. Show the employee's first and last name separately, along with the number of customer orders they have worked on.

from person in Employees
orderby person.LastName, person.FirstName
select new
{
	person.FirstName,
	person.LastName,
	OrderCount = person.SalesRepOrders.Count()
}
// D) List all the employees and sort the result in ascending order by last name, then first name. Show the employee's first and last name separately, along with the number of customer orders they have worked on.
//same as c

// E) Group all customers by city. Output the city name, along with the company name, contact name and title, and the phone number.

from company in Customers
group company by company.Address.City into customersByCity
select new 
{
	City = customersByCity.Key,
	Customers = from buyer in customersByCity
				select new
				{
					buyer.CompanyName,
					buyer.ContactName,
					buyer.ContactTitle,
					buyer.Phone
				}
}

// F) List all the Suppliers, by Country

from vendor in Suppliers
group vendor by vendor.Address.Country into nationalSuppliers
select new 
{
	Country = nationalSuppliers.Key,
	Suppliers = from company in nationalSuppliers
				select company.CompanyName
}





























