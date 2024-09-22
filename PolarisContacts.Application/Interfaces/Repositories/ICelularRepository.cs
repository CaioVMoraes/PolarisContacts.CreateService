﻿using PolarisContacts.Domain;
using System.Data;
using System.Threading.Tasks;

namespace PolarisContacts.Application.Interfaces.Repositories
{
    public interface ICelularRepository
    {
        Task<int> AddCelular(Celular celular, IDbConnection connection, IDbTransaction transaction);
    }
}
