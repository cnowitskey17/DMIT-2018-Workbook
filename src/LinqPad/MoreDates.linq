<Query Kind="Statements">
  <Connection>
    <ID>8b805d54-0169-4933-af92-694e83a46842</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WestWind</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

//Orders.Max(sale => sale.OrderDate).Value.Month


from sale in Orders
where sale.OrderDate.Value.Month == 5
	&& sale.OrderDate.Value.Year == 2018
select new 
{
	Customer = sale.Customer.CompanyName,
	ResponseTime = sale.OrderDate.Value - sale.OrderDate.Value, //use .Value because orderdate is nullable
	PaymentDueOn = sale.PaymentDueDate,
	FirstPayment = sale.Payments.First().PaymentDate,
	PaymentResponseTime = sale.Payments.First().PaymentDate - sale.PaymentDueDate.Value
}


DateTime.DaysInMonth(2020, 2).Dump("Days in feb, 2020");
DateTime today = DateTime.Today;
var fiveDaysLater = today.AddDays(5);
fiveDaysLater.Dump();
var delay = new TimeSpan(48, 15, 22);
delay.Dump();
today.Add(delay).Dump();
today.ToString("MMM dd yyyy").Dump();

DateTime now = DateTime.Now;
while(true)
{
	now.Dump();
}