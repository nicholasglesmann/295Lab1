using CS296NCommunityWebsiteNicholasGlesmann.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS295NCommunityWebsiteNicholasGlesmann.Repositories
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Response> Responses { get; set; }
        public DbSet<SignificantPerson> SignificantPeople { get; set; }
    }
}
