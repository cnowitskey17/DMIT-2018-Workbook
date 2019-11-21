using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WestWindSystem.DAL;
using WestWindSystem.DataModels;
using WestWindSystem.Entities;

namespace WestWindSystem.BLL
{
    [DataObject]
    public class OrderProcessingController
    {
        #region Queries
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<OutstandingOrder> LoadOrders(int supplierId)
        {
            
            //TODO: Implement this method with the following
            /*
             * -Validation - Make sure the supplier ID exists, otherwise throw an exception - [Advanced:] Make sure the logged-in user works for the identified supplier.
             * Query for outstanding orders, getting data from the following tables:
             * TODO: List table names
             */
             using (var context = new WestWindContext()) //Using my DAL object
            {
                //Validation
                var supplier = context.Suppliers.Find(supplierId);
                if(supplier == null)
                {
                    throw new Exception("Invalid supplier - unable to load orders");
                }
                // Processing
                var result =
                    from sale in context.Orders
                    where !sale.Shipped
                    && sale.OrderDate.HasValue
                select new OutstandingOrder
                {
                    OrderId = sale.OrderID,
                    ShipToName = sale.ShipName,
                    OrderDate = sale.OrderDate.Value,//add to nullable field
                    RequiredBy = sale.RequiredDate.Value,
                    OutstandingItems = from item in sale.OrderDetails
                                       where item.Product.SupplierID == supplierId
                                       select new OrderItem
                                       {
                                           ProductID = item.ProductID,
                                           ProductName = item.Product.ProductName,
                                           Qty = item.Quantity,
                                           QtyPerUnit = item.Product.QuantityPerUnit,
                                           //TODO: Figure out the outstanding quantity
                                           //								Outstanding = (from ship in item.Order.Shipments
                                           //											  from shipItem in ship.ManifestItems
                                           //											  where shipItem.ProductID == item.ProductID
                                           //											  select shipItem.ShipQuantity).Sum()
                                       },
                    FullShippingAddress = //TODO: How to use shipaddressID,
                                            sale.Customer.Address.Street + Environment.NewLine +
                                            sale.Customer.Address.City + ", " +
                                            sale.Customer.Address.Region + Environment.NewLine +
                                            sale.Customer.Address.Country + " " +
                                            sale.Customer.Address.PostalCode,
                    Comments = sale.Comments
                };
                            return result.ToList();
            }
        }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<ShipperSelection> ListShippers()
        {
            using (var context = new WestWindContext())
            {
                var result = from shipper in context.Shippers
                             orderby shipper.CompanyName
                             select new ShipperSelection
                             {
                                 ShipperId = shipper.ShipperID,
                                 Shipper = shipper.CompanyName
                             };
                return result.ToList();
            }
        }
        #endregion

        #region Commands
        public void ShipOrder(int orderId, ShippingDirections shipping, List<ShippedItem> items)
        {
            using (var context = new WestWindContext())
            {
                //OrderId must be valid
                var existingOrder = context.Orders.Find(orderId);
                if (existingOrder == null)
                    throw new Exception("Order does not exist");
                if (existingOrder.Shipped)
                    throw new Exception("this order has already been completed");
                if (!existingOrder.OrderDate.HasValue)
                    throw new Exception("This order is not ready to be shipper (no order data has been specified");

                //ShippingDirections is requred (cannot be null)
                if (shipping == null) throw new Exception("No shipping details provided");

                //Shipper must exist
                var shipper = context.Shippers.Find(shipping.ShipperId);
                if (shipper == null) throw new Exception("Invalid shipperID");

                //Freight charge must be either null(no charges) or > $0.00
                // TODO: Q) Should I just convert a $0 charge to a null?
                if (shipping.FreightCharge.HasValue && shipping.FreightCharge <= 0)
                    throw new Exception("Freight charge must be either a positive value or no charge");

                //List<ShippedItem> cannot be empty/null
                if (items == null || !items.Any())
                    throw new Exception("No products identified for shipping");

                //The products must be on the order...
                foreach(var item in items)
                {
                    if (item == null) throw new Exception("Blank items listed in the products to be shipped");
                    if (!existingOrder.OrderDetails.Any(x => x.ProductID.ToString() == item.Product))
                        throw new Exception($"The product {item.Product} does not exist on the order");
                    //...AND items that this supplier provides

                    // TODO: Quantities must be greater than zero and less than or equal to the quantity outstanding
                }
                //TODO: Processing (tables/data that must be updated/inserted/deleted/whatever)
                //1. Create new Shipment
                var ship = new Shipment
                {
                    OrderID = orderId,
                    ShipVia = shipping.ShipperId,
                    TrackingCode = shipping.TrackingCode,
                    FreightCharge = shipping.FreightCharge.HasValue ? shipping.FreightCharge.Value : 0,
                    ShippedDate = DateTime.Now
                };
                // Create manifest items for shipment
                foreach (var item in items)
                {
                    //Notice that I'm adding the manifest item to the shipment object rather than directly to the database context.
                    //That's because be adding to the Shipment object the correct foreign key fields will be assigned to the new data.
                    ship.ManifestItems.Add(new ManifestItem
                    {
                        ProductID = int.Parse(item.Product),
                        ShipQuantity = item.Quantity
                    });
                }
                // 3. TODO: Check if order is complete; if so, update Order.Shipped

                // 4. Add the shipment to the context
                context.Shipments.Add(ship);

                // 5. Save the changes as a single transaction
                context.SaveChanges();
            }

        }
        #endregion
    }
}
