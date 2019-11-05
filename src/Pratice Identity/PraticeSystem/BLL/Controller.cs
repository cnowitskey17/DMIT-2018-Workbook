using PraticeSystem.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraticeSystem.BLL
{
    [DataObject]
    public class Controller
    {
        public List<Staff> ListStaff()
        {
            using(var context = new DemoContext())
            {
                return context.Staffs.ToList();
            }
        }
    }
}
