using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cloud_System_dev_ops.Models;

namespace Cloud_System_dev_ops.Repo
{
    public interface IRepository<Product>
    {
        bool UpdateObject(StaffModel Object, bool Return);


        StaffModel CreateObject(StaffModel Object);

        IEnumerable<Models.StaffModel> GetObject();
    }
}
