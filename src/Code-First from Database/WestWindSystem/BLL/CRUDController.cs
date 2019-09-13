using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WestWindSystem.DAL;
using WestWindSystem.Entities;

namespace WestWindSystem.BLL
{
    [DataObject] //for the <ObjectDataSource> COntrol
    public class CRUDController
    {
        #region Products CRUD
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Product> ListProducts()
        {
            using(var context = new WestWindContext())
            {
                return context.Products.ToList();
            }
        }
        public List<Supplier> ListSupplierss()
        {
            using (var context = new WestWindContext())
            {
                return context.Suppliers.ToList();
            }
        }

        public List<Category> ListCategories()
        {
            using (var context = new WestWindContext())
            {
                return context.Categories.ToList();
            }
        }

        public List<Address> ListAddresses()
        {
            using (var context = new WestWindContext())
            {
                return context.Addresses.ToList();
            }
        }
        //make methods for suppliers, categories and addresses
        #endregion
    }
}
