using Microsoft.EntityFrameworkCore;


namespace LinkShortener.Models
{
    class LinkShortenerAPIContext : DbContext
    {
        public LinkShortenerAPIContext(DbContextOptions<LinkShortenerAPIContext> options) : base(options)
        {
           
        }
  
        DbSet<LinkWithKey> Links {get; set;}
    }
}