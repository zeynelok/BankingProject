﻿using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
   public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        List<T> GetAll();    
        void Add(T entity); 
    }
}
