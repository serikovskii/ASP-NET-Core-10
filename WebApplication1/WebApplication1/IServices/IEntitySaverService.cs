﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DTOs;

namespace WebApplication1.Services
{
    public interface IEntitySaverService
    {
        Task SaveEntity(EntityDTO entity);
    }
}
