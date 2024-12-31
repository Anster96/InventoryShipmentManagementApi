using InventoryShipmentManagementApi.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryShipmentManagementApi.DB
{
    public class InventoryDbContext : DbContext
    {
        public DbSet<InventoryItem> InventoryItems { get; set; }
      

        public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options) 
        {

        }
    }

}
