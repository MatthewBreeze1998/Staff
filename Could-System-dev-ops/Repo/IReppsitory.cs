using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Could_System_dev_ops.Models;

namespace Could_System_dev_ops.Repo
{
    public interface IRepository<Product>
    {



        bool UpdateObject(StaffModel Object, bool Return);


        StaffModel CreateObject(StaffModel Object);

        IEnumerable<Models.StaffModel> GetObject();







    }
}
