﻿using PolarisContacts.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PolarisContacts.Application.Interfaces.Services
{
    public interface ICelularService
    {
        Task AddCelular(Celular celular);
    }
}
