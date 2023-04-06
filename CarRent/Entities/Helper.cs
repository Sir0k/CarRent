using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace CarRent.Entities
{
    internal class Helper
    {
        public static Context DbContext;

        public DbSet<Workers> Workers { get; set; }
    }
}
