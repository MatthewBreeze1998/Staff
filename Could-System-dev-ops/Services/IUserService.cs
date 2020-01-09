using Cloud_System_dev_ops.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cloud_System_dev_ops.Services
{
    public interface IUserService
    {

        Task<UserMetaData> Edituser(UserMetaData User);
    
    }
}
