﻿using Could_System_dev_ops.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Could_System_dev_ops.Repo
{
    public interface IUserRepositry
    {

        Task<UserMetaData> Edituser(UserMetaData User);
    
    }
}