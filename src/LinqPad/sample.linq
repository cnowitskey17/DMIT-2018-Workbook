<Query Kind="Expression">
  <Connection>
    <ID>697cb14f-6eec-4ebe-8740-fe67fb0700ec</ID>
    <Server>.</Server>
    <Database>WestWind</Database>
  </Connection>
</Query>

from cat in Categories
select new //ProductCategory
{
	CategoryName = cat.CategoryName,
	Description = cat.Description,
	Picture = cat.Picture.ToImage(), //note: remove .ToImage for visual sutdio
	MimeType = cat.PictureMimeType,
	Products = from item in cat.Products
	        select new //ProductSummary
	        {
	            Name = item.ProductName,
	            Price = item.UnitPrice,
	            Quantity = item.QuantityPerUnit
	        }
}