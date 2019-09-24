using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppCRUD.Admin
{
    public partial class ViewSuppliers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SupplierListView_ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            // this fires just before the listview calls the objectdatasource control to do an insert.
            ; //no-op
        }

        protected void SupplierListView_ItemInserted(object sender, ListViewInsertedEventArgs e)
        {
            //this fires after the ODS has returned from performing an insert.
            ;
        }

        protected void SuppliersDataSource_Inserting(object sender, ObjectDataSourceMethodEventArgs e)
        {
            ; //Before calling BLL
        }

        protected void SuppliersDataSource_Inserted(object sender, ObjectDataSourceStatusEventArgs e)
        {
            ; //after calling BLL
            if(e.Exception != null)
            {
                Exception inner = e.Exception;
                while (inner.InnerException != null)
                    inner = inner.InnerException;

                string message = $"Problem inserting: {inner.GetType().Name }<blockquote>{ inner.Message }</blockquote>";

                if(inner is DbEntityValidationException)
                {
                    // safe type-cast
                    var actual = inner as DbEntityValidationException;
                    message += "<ul>";
                    foreach(var detail in actual.EntityValidationErrors)
                    {
                        message += $"<li>{detail.Entry.Entity.GetType().Name}";
                        message += "<ol>";
                        foreach (var error in detail.ValidationErrors)
                        {
                            message += $"<li>{error.ErrorMessage}</li>";
                        }
                        message += "</ol></li>";
                    }
                }

                MessageLabel.Text = message;
                e.ExceptionHandled = true;
            }
        }
    }
}