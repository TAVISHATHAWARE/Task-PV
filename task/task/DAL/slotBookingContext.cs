using Microsoft.EntityFrameworkCore;
using task.models;

namespace task.DAL
{
    public class EventDbContext : DbContext
    {
        public DbSet<EventSlot> EventSlots { get; set; }

        public EventDbContext(DbContextOptions<EventDbContext> options) : base(options)
        {
        }
    }
}
