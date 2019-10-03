<Query Kind="Expression">
  <Connection>
    <ID>697cb14f-6eec-4ebe-8740-fe67fb0700ec</ID>
    <Server>.</Server>
    <Database>WestWind</Database>
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
	Employees = from emp in reg.Region
				select new
}

// B) List all the Customers by Company Name. Include the Customer's company name, contact name, and other contact information in the result.

// C) List all the employees and sort the result in ascending order by last name, then first name. Show the employee's first and last name separately, along with the number of customer orders they have worked on.

// D) List all the employees and sort the result in ascending order by last name, then first name. Show the employee's first and last name separately, along with the number of customer orders they have worked on.

// E) Group all customers by city. Output the city name, aalong with the company name, contact name and title, and the phone number.

// F) List all the Suppliers, by Country