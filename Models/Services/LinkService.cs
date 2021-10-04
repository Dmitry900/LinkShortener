using System;
namespace LinkShortener.Models
{
    class LinkService
    {
        private IRepository<LinkWithKey> Links{get;set;}
        private char[] alphabet = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray(); 

        public IEntity CreateEntity(string longLink)
        {
            var Entity = new LinkWithKey();
            Entity.LongLink = longLink;
            Entity.Id = Links.GetAll().Result.Count + 1;
            Entity.Key = IdToShortURL(Entity.Id);
            return Entity;
        }
        private string IdToShortURL(int n)
        {
           
            string shortLink = "";
            while (n > 0)
            {
                shortLink += alphabet[n % 62];
                n /= 62;
            }
            char[] result = shortLink.ToCharArray();
            Array.Reverse( result );
            return new string( result );

        }
        private int ShortURLtoID(string shortLink)
        {
            int id = 0; // initialize result
            int i = 1;
            // A simple base conversion logic
            foreach(char c in shortLink)
            {   
                id += alphabet.ToString().IndexOf(c) * (int)Math.Pow(62, shortLink.Length - i);
                i += 1;
            }
            return id;
        }
         
    }
    
}