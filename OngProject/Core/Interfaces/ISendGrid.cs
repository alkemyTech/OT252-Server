﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.Interfaces
{
    public interface ISendGrid
    {
        Task WelcomeEmail(string email);
        Task ContactEmail(string email);
    }
}
