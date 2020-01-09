using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cloud_System_dev_ops.Models;

namespace Cloud_System_dev_ops.Repo
{
    public interface IRepository<T>
    {
        T UpdateObject(T Object);

        T CreateObject(T Object);

        IEnumerable<T> GetObjects();

        T DeleteObject(T Object);
    }
}
