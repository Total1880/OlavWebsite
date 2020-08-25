using System.Linq;
using System.Collections.Generic;
using System.Net;
using Cookie = OlavWebsite.Core.Cookie;

namespace OlavWebsite.Data
{
    public interface ICookieData
    {
        IEnumerable<Cookie> GetAllCookies();
    }

    public class InMemoryCookieData : ICookieData
    {
        List<Cookie> cookies;
        public InMemoryCookieData()
        {
            cookies = new List<Cookie>()
            {
                new Cookie {Id = 1, Name="Luxe Cornet", Diameter = (float)4.2, Type = Core.CookieType.Cone },
                new Cookie {Id = 2, Name="Mini Tulp", Diameter = 3, Type = Core.CookieType.Tulips },
                new Cookie {Id = 3, Name="Grove Galet", Diameter = (float)10.5, Type = Core.CookieType.Cone }
            };
        }

        public IEnumerable<Cookie> GetAllCookies()
        {
            return from c in cookies
                   orderby c.Name
                   select c;
        }
    }
}
