﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNETCoreIdentityDemo_Application.IServices
{
    public interface ISmsService
    {
        Task<bool> SendSmsAsync(string phoneNumber, string code);

    }
}
