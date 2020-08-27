using Microsoft.EntityFrameworkCore;
using OlavWebsite.Core;
using System.Collections.Generic;
using System.Linq;

namespace OlavWebsite.Data
{
    public class SqlCookieData : ICookieData
    {
        private readonly OlavWebsiteDbContext dbContext;

        public SqlCookieData(OlavWebsiteDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Cookie Add(Cookie newCookie)
        {
            dbContext.Add(newCookie);
            return newCookie;
        }

        public int Commit()
        {
            return dbContext.SaveChanges();
        }

        public Cookie Delete(int id)
        {
            var cookie = GetById(id);

            if (cookie != null)
            {
                dbContext.CookieList.Remove(cookie);
            }

            return cookie;
        }

        public Cookie GetById(int id)
        {
            return dbContext.CookieList.Find(id);
        }

        public IEnumerable<Cookie> GetCookiesByName(string name)
        {
            var query = from c in dbContext.CookieList
                        where c.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                        orderby c.Name
                        select c;

            return query;
        }

        public int GetCountOfCookies()
        {
            return dbContext.CookieList.Count();
        }

        public Cookie Update(Cookie updatedCookie)
        {
            var entity = dbContext.CookieList.Attach(updatedCookie);
            entity.State = EntityState.Modified;

            return updatedCookie;
        }
    }
}
