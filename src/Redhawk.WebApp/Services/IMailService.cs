﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Redhawk.WebApp.Services
{
    public interface IMailService
    {
		bool SendMail(string to, string from, string subject, string body);
    }
}
