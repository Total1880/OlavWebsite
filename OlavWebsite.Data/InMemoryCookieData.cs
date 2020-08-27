using System.Linq;
using System.Collections.Generic;
using Cookie = OlavWebsite.Core.Cookie;

namespace OlavWebsite.Data
{
    public class InMemoryCookieData : ICookieData
    {
        readonly List<Cookie> cookies;

        public InMemoryCookieData()
        {
            cookies = new List<Cookie>()
            {
                new Cookie {Id = 1, Name="Luxe Cornet", Diameter = (float)4.2, Type = Core.CookieType.Cone },
                new Cookie {Id = 2, Name="Mini Tulp", Diameter = 3, Type = Core.CookieType.Tulips },
                new Cookie {Id = 3, Name="Grove Galet", Diameter = (float)10.5, Type = Core.CookieType.Cone }
            };
        }

        public IEnumerable<Cookie> GetCookiesByName(string name = null)
        {
            return from c in cookies
                   where string.IsNullOrEmpty(name) || c.Name.StartsWith(name)
                   orderby c.Name
                   select c;
        }

        public Cookie GetById(int id)
        {
            return cookies.SingleOrDefault(c => c.Id == id);
        }

        public Cookie Update(Cookie updatedCookie)
        {
            var cookie = cookies.SingleOrDefault(c => c.Id == updatedCookie.Id);

            if (cookie != null)
            {
                cookie.Name = updatedCookie.Name;
                cookie.Diameter = updatedCookie.Diameter;
                cookie.Type = updatedCookie.Type;
            }

            return cookie;
        }

        public Cookie Add(Cookie newCookie)
        {
            cookies.Add(newCookie);
            newCookie.Id = cookies.Max(c => c.Id) + 1;
            return newCookie;
        }

        public Cookie Delete(int id)
        {
            var cookie = cookies.FirstOrDefault(c => c.Id == id);

            if (cookie != null)
            {
                cookies.Remove(cookie);
            }

            return cookie;
        }

        public int Commit()
        {
            return 0;
        }

        public int GetCountOfCookies()
        {
            return cookies.Count();
        }
    }
}
