using AppointmentManagerBackEnd;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentManagerBackEnd.Data
{
    public class CallManagerDbContext : DbContext
    {
        public DbSet<AppointmentsManagerShared.Call> Calls { get; set; }

        public CallManagerDbContext(DbContextOptions options)
            : base(options) { }
    }
}
