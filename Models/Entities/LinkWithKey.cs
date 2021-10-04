using System;
namespace LinkShortener.Models
{
    class LinkWithKey : IEntity
    {
        public int Id {get; set;}
        public string LongLink { get; set; }
        public string Key { get; set; }
    }
}