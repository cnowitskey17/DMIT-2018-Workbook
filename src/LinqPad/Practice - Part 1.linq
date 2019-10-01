<Query Kind="Expression">
  <Connection>
    <ID>697cb14f-6eec-4ebe-8740-fe67fb0700ec</ID>
    <Server>.</Server>
    <Database>WestWind</Database>
  </Connection>
</Query>

// Practice questions - do each one in a separate LinqPad query.

//A) List all the customer company names for those with more than 5 orders.

from company in Customers
where company.Orders.Count > 5
select company.CompanyName

/*B) Get a list of all the region names*/

from region in Regions
select new { Region = region.RegionDescription }

/*C) Get a list of all the territory names*/

(from territory in Territories
select  territory.TerritoryDescription).Distinct()

/*D) List all the regions and the number of territories in each region*/

from region in Regions
select new 
{ 
	Region = region.RegionDescription,
	Territories = region.Territories.Count
}

/*E) List all the region and territory names in a "flat" list*/

from region in Territories
orderby region.Region.RegionDescription
select new 
{ 
	Region = region.Region.RegionDescription,
	Territories = region.TerritoryDescription
}

/*F) List all the region and territory names as an "object graph"
   - use a nested query*/

from region in Regions
select new 
{
	Region = 		region.RegionDescription,
	Territories = 	from territory in Territories
					select territory.TerritoryDescription
}

/*G) List all the product names that contain the word "chef" in the name.*/

(from product in Products
where product.ProductName.Contains("chef")
select product.ProductName).ToList()

/*H) List all the discontinued products, specifying the product name and unit price.*/

(from product in Products
where product.Discontinued
select new
{
	product.ProductName, 
	product.UnitPrice
}).ToList()

/*I) List the company names of all Suppliers in North America (Canada, USA, Mexico)*/

from data in Suppliers
where 	data.Address.Country == "Canada" || data.Address.Country == "USA" || data.Address.Country == "Mexico"
select data.CompanyName



