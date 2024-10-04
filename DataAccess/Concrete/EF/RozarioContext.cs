using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EF
{
    public class RozarioContext : DbContext
    {

        public RozarioContext(DbContextOptions<RozarioContext> options)
       : base(options)
        {
        }
      
        public DbSet<Post> Posts { get; set; }
        public DbSet<FeedBack> FeedBacks { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<GalleryItem> GalleryItems { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Archive> Archives { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<User> Users { get; set; }
      



    }
}
