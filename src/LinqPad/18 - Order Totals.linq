<Query Kind="Statements">
  <Connection>
    <ID>05a2444e-14ea-4451-ad3d-3398e9ff7898</ID>
    <Server>.</Server>
    <Database>WestWind</Database>
  </Connection>
</Query>

// List all the orders showing the order ID, Company Name, Freight Charge,
// and Subtotal (no discounts) as well as the Subtotal of the discount.
var result = from sale in Orders
select new
{
    OrderId = sale.OrderID,
    Company = sale.Customer.CompanyName,
    FreightCharge = sale.Freight,
    Subtotal = sale.OrderDetails.Sum(lineItem => lineItem.Quantity * lineItem.UnitPrice),
    DiscountSubtotal = 
        sale.OrderDetails.Sum(lineItem =>
                              lineItem.Quantity * lineItem.UnitPrice * (decimal)lineItem.Discount)
};

var highestToLowest = result.OrderByDescending(sale => sale.Subtotal);
highestToLowest.Dump();