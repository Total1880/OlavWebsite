using System.Collections.Generic;
using System.Net;
using Cookie = OlavWebsite.Core.Cookie;

namespace OlavWebsite.Data
{
    public interface ICookieData
    {
        IEnumerable<Cookie> GetCookiesByName(string name);
        Cookie GetById(int id);
        Cookie Update(Cookie updatedCookie);
        Cookie Add(Cookie newCookie);
        Cookie Delete(int id);
        int GetCountOfCookies();
        int Commit();
    }
}
