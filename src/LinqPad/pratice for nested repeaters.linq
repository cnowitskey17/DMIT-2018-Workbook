<Query Kind="Expression">
  <Connection>
    <ID>697cb14f-6eec-4ebe-8740-fe67fb0700ec</ID>
    <Server>.</Server>
    <Database>WestWind</Database>
  </Connection>
</Query>

from sup in Suppliers
select new
{
	CompanyName = sup.CompanyName,
	ContactName = sup.ContactName,
	Phone = sup.Phone,
		Products = from item in sup.Products
			select new
			{
				Name = item.ProductName,
				Category = item.Category.CategoryName,
				Price = item.UnitPrice,
				Quantity = item.QuantityPerUnit
			}
}