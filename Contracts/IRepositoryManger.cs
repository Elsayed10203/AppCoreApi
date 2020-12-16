﻿using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryManger
    {
        IproductRepository products { get; }
        Task SaveChangesAsyn();
    }
}
