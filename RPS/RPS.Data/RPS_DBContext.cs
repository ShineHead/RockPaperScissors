using Microsoft.EntityFrameworkCore;
using RPS.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPS.Data
{
    public class RPS_DBContext : DbContext
    {

        public RPS_DBContext(DbContextOptions<RPS_DBContext> options) : base (options)
        {

        }

        public DbSet<GameData> Games { get; set; }
    }
}
