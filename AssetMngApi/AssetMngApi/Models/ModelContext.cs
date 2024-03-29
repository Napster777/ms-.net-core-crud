﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetMngApi.Models
{
    public class ModelContext :DbContext
    {
        public ModelContext(DbContextOptions<ModelContext> options)
            :base(options)
        {
        }
        public DbSet<Assets> assets { get; set; }
    }
}
