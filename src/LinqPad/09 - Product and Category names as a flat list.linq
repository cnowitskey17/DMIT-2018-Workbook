<Query Kind="Expression">
  <Connection>
    <ID>697cb14f-6eec-4ebe-8740-fe67fb0700ec</ID>
    <Server>.</Server>
    <Database>WestWind</Database>
  </Connection>
</Query>

// List all the product and category names in a "flat" list
from data in Products
select new
{
   Product = data.ProductName,
   Category = data.Category.CategoryName
}