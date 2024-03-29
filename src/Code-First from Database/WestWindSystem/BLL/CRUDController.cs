﻿using System;
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
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Supplier> ListSuppliers()
        {
            using (var context = new WestWindContext())
            {
                return context.Suppliers.Include(nameof(Supplier.Address)).ToList();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void AddSuppliers(Supplier item)
        {
            using(var context = new WestWindContext())
            {
                context.Suppliers.Add(item);
                context.SaveChanges();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public void UpdateSupplier(Supplier item)
        {
            using (var context = new WestWindContext())
            {
                var existing = context.Entry(item);
                existing.State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public void DeleteSupplier(Supplier item)
        {
            using (var context = new WestWindContext())
            {
                var existing = context.Suppliers.Find(item.SupplierID);
                context.Suppliers.Remove(existing);
                context.SaveChanges();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Category> ListCategories()
        {
            using (var context = new WestWindContext())
            {
                return context.Categories.ToList();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Region> ListRegions()
        {
            using (var context = new WestWindContext())
            {
                return context.Regions.ToList();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Address> ListAddresses()
        {
            using (var context = new WestWindContext())
            {
                return context.Addresses.ToList();
            }
        }
        //make methods for suppliers, categories and addresses

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void AddAddress(Address item)
        {
            using (var context = new WestWindContext())
            {
                context.Addresses.Add(item);
                context.SaveChanges();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public void UpdateAddress(Address item)
        {
            using (var context = new WestWindContext())
            {
                var existing = context.Entry(item);
                existing.State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public void DeleteAddress(Address item)
        {
            using (var context = new WestWindContext())
            {
                var existing = context.Addresses.Find(item.AddressID);
                context.Addresses.Remove(existing);
                context.SaveChanges();
            }
        }
        #endregion
    }
}
