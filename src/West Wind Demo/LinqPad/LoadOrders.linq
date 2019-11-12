<Query Kind="Program">
  <Connection>
    <ID>c4264b7a-952b-4bdd-948f-b22fe85e3447</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WestWind</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

void Main()
{
	int supplier = 8;	//2, 7, 8, 16, 19
	var output = LoadOrders(supplier);
	output.Dump();
}

public List<OutstandingOrder> LoadOrders(int supplierId)
{
var result = 
	from sale in Orders
	where !sale.Shipped
	 && sale.OrderDate.HasValue
	select new OutstandingOrder
	{
		OrderId = sale.OrderID,
		ShipToName = sale.ShipName,
		OrderDate = sale.OrderDate.Value,//add to nullable field
		RequiredBy = sale.RequiredDate.Value,
		//OutstandingItems
		//FullShippingAddress
		Comments = sale.Comments
	};
	return result.ToList();
}

    public class OutstandingOrder
    {
        public int OrderId { get; set; }
        public string ShipToName { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredBy { get; set; }
        public int DaysRemaining { get; } //Calculated
        public IEnumerable<OrderItem> OutstandingItems { get; set; }
        public string FullShippingAddress { get; set; }
        public string Comments { get; set; }
    }
	
	    public class OrderItem
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public short Qty { get; set; }
        public string QtyPerUnit { get; set; }
        public short Outstanding { get; set; }
    }
// Define other methods and classes here
