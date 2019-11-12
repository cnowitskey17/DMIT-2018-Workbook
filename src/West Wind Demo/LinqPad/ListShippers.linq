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
	var output = ListShippers();
	output.Dump();
}

// Define other methods and classes here
	    public List<ShipperSelection> ListShippers()
        {
			 var result = from shipper in Shippers
			 			  orderby shipper.CompanyName
			 			  select new ShipperSelection
						  {
						  	ShipperId = shipper.ShipperID,
							Shipper = shipper.CompanyName
						  };
			return result.ToList();
        }
		
		    public class ShipperSelection
    {
        public int ShipperId { get; set; }
        public string Shipper { get; set; }

    }