﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteDesenvolvimento.Dominio.Dominio;

namespace TesteDesenvolvimento.Data.Context
{
    public class DbContexto : DbContext
    {
        public DbContexto(DbContextOptions options)
            :base(options) 
        {
            
        }

        public DbSet<Altitude> Altitudes { get; set; }
    }
}
