﻿using NewComplexManagment.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewComplexManagment.EFPresistence
{
    public class EFUnitOfWork : UnitOfWork
    {
        private readonly EFDataContext _context;

        public EFUnitOfWork(EFDataContext context)
        {
            _context = context;
        }
        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}
