using Cloud_System_dev_ops.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cloud_System_dev_ops.Repo
{
    public class SuccessIUserService : IUserRepositry
    {
        public Task<UserMetaData> Edituser(UserMetaData User)
        {
            UserMetaData user = null;
            return Task.FromResult(user);
        }
    }
}
