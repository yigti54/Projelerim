﻿using Core.DataAccess;
using Entities.Concrete.EntityFramework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ITaskDal : IEntityRepository<Task1>
    {

    }
}
